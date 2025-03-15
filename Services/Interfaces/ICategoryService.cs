using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICategoryService
    {
        Task AddCategoryFromService(Category category);
        Task UpdateCategoryFromService(Category category);
        Task DeleteCategoryFromService(Category category);
        Task<IEnumerable<Category>> GetAllCategories(bool v);
        Task<Category> GetCategoryById(int id);

    }
}
