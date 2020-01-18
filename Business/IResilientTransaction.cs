namespace Business
{
    using System;
    using System.Data;
    using System.Threading.Tasks;

    public interface IResilientTransaction
    {
        Task ExecuteAsync(Func<Task> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> func, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}
