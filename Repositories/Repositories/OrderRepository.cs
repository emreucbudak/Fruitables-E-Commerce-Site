using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddOrder(Order order)
        {
            await Add(order);
        }

        public async Task DeleteOrder(Order order)
        {
            await Delete(order);
        }

        public async Task<IEnumerable<Order>> GetAllOrders(bool v)
        {
            return await GetAll(v).ToListAsync();
        }

        public async Task<Order> GetOrderById(int id, bool v)
        {
            return await GetById(b=> b.Id == id, v);
        }

        public async Task UpdateOrder(Order order)
        {
            await Update(order);
        }
    }
}
