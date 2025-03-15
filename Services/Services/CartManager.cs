using Entities.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CartManager : ICartService
    {
        private readonly IRepositoryManager _rp;

        public CartManager(IRepositoryManager rp)
        {
            _rp = rp;
        }

        public async Task AddCartFromService(Cart cart)
        {
            await _rp.ICartRepositories.AddCart(cart);
            _rp.Save();

        }

        public async Task DeleteCartFromService(Cart cart)
        {
            await _rp.ICartRepositories.DeleteCart(cart);
            _rp.Save();
        }

        public async Task<IEnumerable<Cart>> GetAllCarts(bool v)
        {
            return await _rp.ICartRepositories.GetAllCarts(v);
        }

        public async Task<Cart> GetCartByIdFromService(int id, bool v)
        {
            return await _rp.ICartRepositories.GetCartByID(id);
        }

        public async Task UpdateCartFromService(Cart cart)
        {
            await _rp.ICartRepositories.UpdateCart(cart);
            _rp.Save();
        }
    }
}
