using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.DataAccess
{
    public interface IUnitOfWork
    {
        void Add<T>(T entity) where T : IEntity;

        void AddRange<T>(IEnumerable<T> entities) where T : IEntity;

        IOrderRepository OrderRepository { get; }

        ISuggestionRepository SuggestionRepository { get; }

        Task SaveAsync();
    }
}
