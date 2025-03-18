using Entities.Exceptions;
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

        public async Task DeleteCartFromService(int cart)
        {
            var x = await GetCartByIdFromService(cart, false);
 
            await _rp.ICartRepositories.DeleteCart(x);
            _rp.Save();
        }

        public async Task<IEnumerable<Cart>> GetAllCarts(bool v)
        {
            return await _rp.ICartRepositories.GetAllCarts(v);
        }

        public async Task<Cart> GetCartByIdFromService(int id, bool v)
        {
            var x =  await _rp.ICartRepositories.GetCartByID(id);
            if ( x == null) { throw new CartNotFoundExceptions(id); }
            return x;
        }

        public async Task UpdateCartFromService(Cart cart)
        {
            var x = await GetCartByIdFromService(cart.ID, false);
            x.CartItems = cart.CartItems;
            x.User = cart.User;
            x.UserID = cart.UserID;
            await _rp.ICartRepositories.UpdateCart(x);
            _rp.Save();
        }
    }
}
