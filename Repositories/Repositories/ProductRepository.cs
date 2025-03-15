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
    public class ProductRepository : RepositoryBase<Products>, IProductsRepositories
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddProduct(Products product)
        {
            await Add(product);
        }

        public async Task DeleteProduct(Products product)
        {
            await Delete(product);
        }

        public async Task<IEnumerable<Products>> GetAllProducts(bool v)
        {
            return await GetAll(v).ToListAsync();
        }

        public async Task<Products> GetProductsById(int id, bool v)
        {
            return await GetById(b => b.ProductId == id, v);
        }

        public async Task UpdateProduct(Products product)
        {
            await UpdateProduct(product);
        }
    }
}
