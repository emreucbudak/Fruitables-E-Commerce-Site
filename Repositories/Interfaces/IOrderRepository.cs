using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrder (Order order);
        Task DeleteOrder (Order order);
        Task<IEnumerable<Order>> GetAllOrders (bool v);
        Task<Order> GetOrderById(int id,bool v);
        Task UpdateOrder (Order order);
    }
}
