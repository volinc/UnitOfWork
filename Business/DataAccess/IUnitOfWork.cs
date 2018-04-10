using System.Threading.Tasks;

namespace Business.DataAccess
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }

        ISuggestionRepository Suggestions { get; }

        Task SaveAsync();
    }
}
