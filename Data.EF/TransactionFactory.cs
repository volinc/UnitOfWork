using Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Data.EF
{
    public class TransactionFactory<TDbContext> : ITransactionFactory where TDbContext : DbContext
    {
        private readonly Func<TDbContext> dbContextFactory;

        /// <summary>
        /// Инициализирует экземпляр типа <see cref="TransactionFactory{TDbContext}"/>.
        /// </summary>
        /// <param name="dbContextFactory"></param>
        public TransactionFactory(Func<TDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <inheritdoc />
        public ITransaction Create(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) 
        {
            var database = dbContextFactory().Database;            
            var dbContextTransaction = database.BeginTransaction(isolationLevel);
            return new Transaction(dbContextTransaction);
        }

        /// <inheritdoc />
        public Task<ITransaction> CreateAsync(CancellationToken cancellationToken = default)
        {
            return CreateAsync(IsolationLevel.ReadCommitted, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<ITransaction> CreateAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default)
        {
            var database = dbContextFactory().Database;
            var dbContextTransaction = await database.BeginTransactionAsync(isolationLevel, cancellationToken);
            return new Transaction(dbContextTransaction);
        }        
    }
}
