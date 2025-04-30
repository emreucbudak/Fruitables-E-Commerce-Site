using Entities.DTO;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IProductsRepositories
    {
        Task AddProduct(Products product);
        Task UpdateProduct(Products product);
        Task DeleteProduct(Products product);
        Task<ProductDtoForList> GetProductsById(int id, bool v);
        Task<PagedList<Products>> GetAllProducts(ProductParameters prdc,bool v);
        Task<Products> GetProductAndCheck(int id , bool v);
        Task<IEnumerable<Products>> GetAllForCategories (ProductParameters prdc);
    }
}
