using AutoMapper;
using Entities.DTO;
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
        private readonly IMapper _mapper;

        public ProductsManager(IRepositoryManager productService, IMapper map, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task AddProductFromService(ProductDtoForInsert prd)
        {
            var x=  _mapper.Map<Products>(prd);
            await _productService.products.AddProduct(x);
            _productService.Save();
        }

        public async Task DeleteProductFromService(int prd)
        {
            var x = await GetProductsFromService(prd);
            await _productService.products.DeleteProduct(x);
            _productService.Save();

        }
        private async Task <Products> GetProductsFromService (int id)
        {
            var x = await _productService.products.GetProductAndCheck(id, false);
            if (x == null)
            {
                throw new ProductsNotFoundExceptions(id);

            }
            return x;
        }

        public async Task<IEnumerable<ProductDtoForList>> GetAllProducts(bool v)
        {
            return await _productService.products.GetAllProducts(v);

        }

        public async Task<ProductDtoForList> GetProductById(int id, bool v)
        {
            var x =  await _productService.products.GetProductsById(id, v);
            if ( x == null)
            {
                throw new ProductsNotFoundExceptions(id);
            }
            return x;
        }

        public async Task UpdateProductFromService(int id,  ProductDtoForUpdate prd)
        {
            var x = await GetProductsFromService(id);

            x.Price = prd.Price;
            x.Name = prd.Name;
            x.Description = prd.Description;
            x.Quentity = prd.Quentity;
            x.ImgUrl = prd.ImgUrl;
            x.IsExpired = prd.IsExpired;
            x.IsDiscount = prd.IsDiscount;
            x.Ratio = prd.Ratio;
            x.CategoryID = prd.CategoryID;
            await _productService.products.UpdateProduct(x);
            _productService.Save();

        }
    }
}
