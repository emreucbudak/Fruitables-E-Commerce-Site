using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICategoryRepositories
    {
        Task AddCategory(Category ctg);
        Task UpdateCategory(Category ctg);
        Task DeleteCategory(Category ctg);
        Task<IEnumerable<Category>> GetAllCategories(bool v);
        Task <Category> GetCategoryById(int id);
    }
}
