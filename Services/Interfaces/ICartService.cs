using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICartService
    {
        Task AddCartFromService(Cart cart);
        Task DeleteCartFromService(int cart);
        Task<IEnumerable<Cart>> GetAllCarts(bool v);
        Task<Cart> GetCartByIdFromService(int id, bool v);
        Task UpdateCartFromService(int id ,Cart cart);
    }
}
