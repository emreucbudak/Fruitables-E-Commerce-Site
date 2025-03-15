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
        Task RemoveOwnProductsFromService(OwnProduct ownProduct);
        Task UpdateOwnProductsFromService(OwnProduct ownProduct);
        Task<IEnumerable<OwnProduct>> GetAllOwnProducts(bool v);
        Task<OwnProduct> GetOwnProductById(int id);

    }
}
