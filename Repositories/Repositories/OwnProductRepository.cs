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
    public class OwnProductRepository : RepositoryBase<OwnProduct>, IOwnProducts
    {
        public OwnProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddOwnProduct(OwnProduct _ownProduct)
        {
            await Add(_ownProduct);
        }

        public async Task<IEnumerable<OwnProduct>> GetAllOwnProducts(bool v)
        {
            return await GetAll(v).ToListAsync();
        }

        public async Task<OwnProduct> GetOwnProductById(int id, bool v)
        {
            return await GetById(b => b.ID == id, v);
        }

        public async Task RemoveOwnProduct(OwnProduct _ownProduct)
        {
            await Delete(_ownProduct);
        }

        public async Task UpdateOwnProduct(OwnProduct _ownProduct)
        {
            await Update(_ownProduct);
        }
    }
}
