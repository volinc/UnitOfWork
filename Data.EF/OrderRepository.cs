using System;
using System.Linq;
using System.Threading.Tasks;
using Business.DataAccess;
using Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.EF
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DispatcherDbContext dbContext;        
        private readonly Mapper mapper;
        
        public OrderRepository(DispatcherDbContext dbContext, Mapper mapper)
        {
            this.dbContext = dbContext;            
            this.mapper = mapper;
        }

        public Order Create(string beginAddress, string endAddress, string commentMessage, DateTimeOffset createdAt)
        {
            var order = Order.CreatePresent(beginAddress, endAddress, commentMessage, createdAt);
            var data = mapper.To(order);
            dbContext.Add(data);
            return order;
        }

        public async Task<Order> ReadByIdAsync(long orderId)
        {
            var data = await dbContext.Orders
                .Where(x => x.Id == orderId)
                .Include(x => x.Comments)
                .SingleOrDefaultAsync();

            return mapper.From(data);
        }
    }
}
