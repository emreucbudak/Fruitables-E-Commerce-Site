using Entities.DTO;
using Entities.Models;
using Entities.RequestFeatures;
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

        public async Task<PagedList<Products>> GetAllProducts(ProductParameters prdct, bool v)
        {
            var page = await GetAll(v)
                                .Include(c => c.Category)
                                                .OrderProducts(prdct.OrderBy)
                                                .SearchCategory(prdct.Category)
                                                .DiscountCheck(prdct.IsDiscount)

                .FilterProducts(prdct.MaxPrice,prdct.MinPrice)
                .SearchProducts(prdct.ProductName)

                .ToListAsync();  




            return PagedList<Products>.ToPagedList(page, prdct.PageSize, prdct.PageNumber);
        }
        public async Task<IEnumerable<Products>> GetAllForCategories (ProductParameters prdct)
        {
            var page = await GetAll(false).Include(c => c.Category).OrderProducts(prdct.OrderBy).SearchCategory(prdct.Category).FilterProducts(prdct.MaxPrice, prdct.MinPrice).ToListAsync();
            return page;
        }

        public async Task<ProductDtoForList> GetProductsById(int id, bool v)
        {
            return await GetAll(v).Where(b=> b.ProductId == id).Include(c=> c.Category).Select(c => new ProductDtoForList
            {
                Name = c.Name,
                Description = c.Description,
                Price = c.Price,
                Ratio = c.Ratio,
                Quentity = c.Quentity,
                IsExpired = c.IsExpired,
                IsDiscount = c.IsDiscount,
                ImgUrl = c.ImgUrl,
                CategoryName = c.Category.CategoryName
            }).FirstOrDefaultAsync();
        }


        public async Task UpdateProduct(Products product)
        {
            await UpdateProduct(product);
        }

        public async Task<Products> GetProductAndCheck(int id, bool v)
        {
            return await GetById(b => b.ProductId == id, v);
        }
    }
}
