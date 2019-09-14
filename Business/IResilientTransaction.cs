namespace Business
{
    using System;
    using System.Threading.Tasks;

    public interface IResilientTransaction
    {
        Task ExecuteAsync(Func<Task> func);

        Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> func);
    }
}
