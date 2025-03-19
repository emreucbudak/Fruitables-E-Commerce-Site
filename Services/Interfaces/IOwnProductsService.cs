using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOwnProductsService
    {
        Task AddOwnProductsFromService(OwnProduct ownProduct);
        Task RemoveOwnProductsFromService(int ownProduct);
        Task UpdateOwnProductsFromService(int id , OwnProduct ownProduct);
        Task<IEnumerable<OwnProduct>> GetAllOwnProducts(bool v);
        Task<OwnProduct> GetOwnProductById(int id);

    }
}
