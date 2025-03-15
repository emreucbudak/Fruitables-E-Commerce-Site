using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICartRepositories
    {
        Task AddCart (Cart cart);
        Task DeleteCart (Cart cart);
        Task<IEnumerable<Cart>> GetAllCarts(bool a);
        Task<Cart> GetCartByID (int id);
        Task UpdateCart(Cart cart);
    }
}
