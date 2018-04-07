using System.Threading.Tasks;
using Business.Entities;

namespace Business.DataAccess
{
    public interface IOrderRepository
    {
        Task<Order> ReadByIdAsync(long id);
    }
}
