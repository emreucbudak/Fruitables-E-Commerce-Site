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
    public class OwnProductsManager : IOwnProductsService
    {
        private readonly IRepositoryManager _rp;

        public OwnProductsManager(IRepositoryManager rp)
        {
            _rp = rp;
        }

        public async Task AddOwnProductsFromService(OwnProduct ownProduct)
        {
            await _rp.ownProducts.AddOwnProduct(ownProduct);
            _rp.Save();
        }

        public async Task<IEnumerable<OwnProduct>> GetAllOwnProducts(bool v)
        {
            return await _rp.ownProducts.GetAllOwnProducts(v);
        }

        public async Task<OwnProduct> GetOwnProductById(int id)
        {
            return await _rp.ownProducts.GetOwnProductById(id,false);
        }

        public async Task RemoveOwnProductsFromService(OwnProduct ownProduct)
        {
            await _rp.ownProducts.RemoveOwnProduct(ownProduct);
            _rp.Save();
        }

        public async Task UpdateOwnProductsFromService(OwnProduct ownProduct)
        {
            await _rp.ownProducts.UpdateOwnProduct(ownProduct);
            _rp.Save();
        }
    }
}
