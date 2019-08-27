namespace Business
{
    using System;

    /// <summary>
    /// Интерфейс транзакции.
    /// </summary>
    public interface ITransaction : IDisposable
    {
        /// <summary>
        /// Фиксирует транзакцию.
        /// </summary>
        void Commit();

        /// <summary>
        /// Откатывает транзакцию.
        /// </summary>
        void Rollback();
    }
}
