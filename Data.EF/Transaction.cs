using Business;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.EF
{
    public class Transaction : ITransaction
    {
        private bool disposed;

        private readonly IDbContextTransaction dbContextTransaction;

        /// <summary>
        /// Инициализирует новый экземпляр типа <see cref="Transaction"/>
        /// </summary>
        /// <param name="database"></param>
        internal Transaction(IDbContextTransaction dbContextTransaction)
        {
            this.dbContextTransaction = dbContextTransaction;
        }

        /// <inheritdoc />
        public void Commit()
        {
            dbContextTransaction.Commit();
        }

        /// <inheritdoc />
        public void Rollback()
        {
            dbContextTransaction.Rollback();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {                                
                dbContextTransaction.Dispose();
                disposed = true;
            }
        }
    }
}
