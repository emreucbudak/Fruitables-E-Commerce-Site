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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepositories
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddCategory(Category ctg)
        {
            await Add(ctg);
        }

        public async Task DeleteCategory(Category ctg)
        {
            await Delete(ctg);
        }

        public async Task<IEnumerable<Category>> GetAllCategories(bool v)
        {
            return await GetAll(v).ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await GetById(b=> b.CategoryID == id , false);
        }

        public async Task UpdateCategory(Category ctg)
        {
            await Update(ctg);
        }
    }
}
