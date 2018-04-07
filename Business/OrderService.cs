using System;
using System.Threading.Tasks;
using Business.DataAccess;
using Business.Entities;

namespace Business
{
    public class OrderService
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;            
        }

        public async Task RunAsync()
        {
            var order = Order.Create("abc", "cba", "123", DateTimeOffset.Now);            
            unitOfWork.Add(order);
            await unitOfWork.SaveAsync();
            
            var orderRepository = unitOfWork.OrderRepository;

            order = await orderRepository.ReadByIdAsync(order.Id);
            order.AddComment("456", DateTimeOffset.Now);
            await unitOfWork.SaveAsync();

            order = await orderRepository.ReadByIdAsync(order.Id);            
        }
    }
}
