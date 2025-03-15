using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IOwnProducts
    {
        Task AddOwnProduct(OwnProduct _ownProduct);
        Task RemoveOwnProduct(OwnProduct _ownProduct);
        Task<OwnProduct> GetOwnProductById(int id,bool v);
        Task UpdateOwnProduct (OwnProduct _ownProduct);
        Task <IEnumerable<OwnProduct>> GetAllOwnProducts(bool v);
    }
}
