using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.DataAccess
{
    public interface ISuggestionRepository
    {
        Task<Suggestion> ReadByIdAsync(long suggestionId);

        Task<IReadOnlyList<Suggestion>> ReadAllByOrderIdAsync(long orderId);
    }
}