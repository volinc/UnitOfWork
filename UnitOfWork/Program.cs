using Business;
using Business.Entities;
using Data.EF;
using System.Threading.Tasks;

namespace UnitOfWork
{
    internal class Program
    {
        private static async Task Main()
        {
            var mapper = new Mapper();
            var dbContext = new DispatcherDbContext();
            var unitOfWork = new Data.EF.UnitOfWork(dbContext, mapper);
            var transactionFactory = new TransactionFactory<DispatcherDbContext>(() => dbContext);
            var orderService = new OrderService(transactionFactory, unitOfWork);

            await dbContext.Database.EnsureCreatedAsync();
            await orderService.RunAsync();
        }
    }
}
