namespace Data.EF
{
    using Business;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class ResilientTransaction<TDbContext> : IResilientTransaction where TDbContext : DbContext
    {
        private readonly Func<TDbContext> dbContextFactory;

        public ResilientTransaction(Func<TDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task ExecuteAsync(Func<Task> func)
        {
            var database = dbContextFactory().Database;
            var strategy = database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = database.BeginTransaction())
                {
                    await func();
                    transaction.Commit();
                }
            });
        }

        public async Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> func)
        {
            var database = dbContextFactory().Database;
            var strategy = database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = database.BeginTransaction())
                {
                    var result = await func();
                    transaction.Commit();
                    return result;
                }
            });
        }
    }
}
