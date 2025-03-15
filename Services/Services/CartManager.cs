using Entities.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CartManager : ICartRepositories
    {
        private readonly IRepositoryManager _rp;

        public CartManager(IRepositoryManager rp)
        {
            _rp = rp;
        }

        public async Task AddCart(Cart cart)
        {
            await _rp.ICartRepositories.AddCart(cart);
            _rp.Save();
        }

        public async Task DeleteCart(Cart cart)
        { 
            await _rp.ICartRepositories.DeleteCart(cart);
            _rp.Save();

        }

        public async Task<IEnumerable<Cart>> GetAllCarts(bool a)
        {
            return await _rp.ICartRepositories.GetAllCarts(a);
        }

        public async Task<Cart> GetCartByID(int id)
        {
            return await _rp.ICartRepositories.GetCartByID(id);
        }

        public async Task UpdateCart(Cart cart)
        {
            await _rp.ICartRepositories.UpdateCart(cart);
            _rp.Save();
        }
    }
}
