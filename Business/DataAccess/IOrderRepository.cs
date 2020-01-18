using System;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.DataAccess
{
    public interface IOrderRepository
    {
        Order Create(string beginAddress, string endAddress, string commentMessage, DateTimeOffset createdAt);

        Task<Order> ReadByIdAsync(long orderId);

        Task<Order[]> ReadOnlyAllAsync();
    }
}
