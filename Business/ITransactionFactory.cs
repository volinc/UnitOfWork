using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Интерфейс фабрики транзакций.
    /// </summary>
    public interface ITransactionFactory
    {
        /// <summary>
        /// Создает транзакцию.
        /// </summary>
        /// <returns>Транзакция.</returns>
        ITransaction Create(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        /// <summary>
        /// Асинхронно создает транзакцию.
        /// </summary>
        /// <returns>Задача создающая транзакцию.</returns>
        Task<ITransaction> CreateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Асинхронно создает транзакцию.
        /// </summary>
        /// <returns>Задача создающая транзакцию.</returns>
        Task<ITransaction> CreateAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default);        
    }
}
