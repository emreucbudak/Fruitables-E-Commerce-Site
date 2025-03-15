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
    public class CartRepository : RepositoryBase<Cart>, ICartRepositories
    {
        public CartRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddCart(Cart cart)
        {
            await Add(cart);
        }

        public async Task DeleteCart(Cart cart)
        {
            await Delete(cart);

        }

        public async Task<IEnumerable<Cart>> GetAllCarts(bool a)
        {
            return await GetAll(false).ToListAsync();
        }

        public async Task<Cart> GetCartByID(int id)
        {
            return await GetById(b => b.ID == id, false);
        }

        public async Task UpdateCart(Cart cart)
        {
           await Update(cart);
        }
    }
}
