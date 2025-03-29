using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public  interface IProductService
    {
        Task AddProductFromService(ProductDtoForInsert prd);
        Task DeleteProductFromService(int prd);
        Task UpdateProductFromService(int id , ProductDtoForUpdate prd);
        Task<IEnumerable<ProductDtoForList>> GetAllProducts(bool v);
        Task<ProductDtoForList> GetProductById(int id , bool v);

    }
}
