using Business;
using Business.Entities;
using Data.EF;

namespace UnitOfWork
{
    internal class Program
    {
        private static void Main()
        {
            var mapper = new Mapper();
            var dbContext = new DispatcherDbContext();
            var unitOfWork = new Data.EF.UnitOfWork(dbContext, mapper);
            var orderService = new OrderService(unitOfWork);

            dbContext.Database.EnsureCreated();
            orderService.RunAsync().Wait();
        }
    }
}
