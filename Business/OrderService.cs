using System;
using System.Threading.Tasks;
using Business.DataAccess;

namespace Business
{
    public class OrderService
    {
        private readonly ITransactionFactory transactionFactory;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(ITransactionFactory transactionFactory, IUnitOfWork unitOfWork)
        {
            this.transactionFactory = transactionFactory;
            this.unitOfWork = unitOfWork;            
        }

        public async Task RunAsync()
        {
            using (var transaction = await transactionFactory.CreateAsync())
            {
                var order = unitOfWork.Orders.Create("abc", "cba", "123", DateTimeOffset.Now);
                await unitOfWork.SaveAsync();

                order = await unitOfWork.Orders.ReadByIdAsync(order.Id);
                order.AddComment("456", DateTimeOffset.Now);
                
                await unitOfWork.SaveAsync();

                order = await unitOfWork.Orders.ReadByIdAsync(order.Id);
                
                transaction.Commit();
            }
        }
    }
}
