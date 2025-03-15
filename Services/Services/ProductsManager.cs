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
    public class ProductsManager : IProductService
    {
        private readonly IRepositoryManager _productService;

        public ProductsManager(IRepositoryManager productService)
        {
            _productService = productService;
        }

        public async Task AddProductFromService(Products prd)
        {
            await _productService.products.AddProduct(prd);
            _productService.Save();
        }

        public async Task DeleteProductFromService(Products prd)
        {
            await _productService.products.DeleteProduct(prd);
            _productService.Save();
        }

        public async Task<IEnumerable<Products>> GetAllProducts(bool v)
        {
            return await _productService.products.GetAllProducts(v);

        }

        public async Task<Products> GetProductById(int id, bool v)
        {
            return await _productService.products.GetProductsById(id, v);
        }

        public async Task UpdateProductFromService(Products prd)
        {
            await _productService.products.UpdateProduct(prd);
            _productService.Save();
        }
    }
}
