using System;
using System.Threading.Tasks;
using Business.DataAccess;

namespace Business
{
    public class OrderService
    {
        private readonly IResilientTransaction resilientTransaction;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IResilientTransaction resilientTransaction, IUnitOfWork unitOfWork)
        {
            this.resilientTransaction = resilientTransaction;
            this.unitOfWork = unitOfWork;            
        }

        public async Task RunAsync()
        {
            await resilientTransaction.ExecuteAsync(async () =>
            {
                var order = unitOfWork.Orders.Create("abc", "cba", "123", DateTimeOffset.Now);
                await unitOfWork.SaveAsync();

                order = await unitOfWork.Orders.ReadByIdAsync(order.Id);
                order.AddComment("456", DateTimeOffset.Now);

                await unitOfWork.SaveAsync();

                order = await unitOfWork.Orders.ReadByIdAsync(order.Id);
            });

            var orders = await unitOfWork.Orders.ReadOnlyAllAsync();
        }
    }
}
