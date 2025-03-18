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

        public async Task DeleteProductFromService(int prd)
        {
            var x = await _productService.products.GetProductsById(prd,false);
            if ( x == null)
            {
                throw new ProductsNotFoundExceptions(prd);
            }
            await _productService.products.DeleteProduct(x);
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
            var x = await _productService.products.GetProductsById(prd.ProductId, false);
            if (x == null)
            {
                throw new ProductsNotFoundExceptions(prd.ProductId);
            }
            x.Price = prd.Price;
            x.Name = prd.Name;
            x.Description = prd.Description;
            x.Quentity = prd.Quentity;
            x.ImgUrl = prd.ImgUrl;
            x.IsExpired = prd.IsExpired;
            x.IsDiscount = prd.IsDiscount;
            x.Ratio = prd.Ratio;
            await _productService.products.UpdateProduct(prd);
            _productService.Save();

        }
    }
}
