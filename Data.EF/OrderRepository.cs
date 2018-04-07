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

        public async Task<Order> ReadByIdAsync(long id)
        {
            var data = await dbContext.Orders
                .Where(x => x.Id == id)
                .Include(x => x.Comments)
                .SingleOrDefaultAsync();

            return mapper.From(data);
        }
    }
}
