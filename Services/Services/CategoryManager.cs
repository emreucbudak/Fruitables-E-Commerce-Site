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
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _categoryService;

        public CategoryManager(IRepositoryManager categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task AddCategoryFromService(Category category)
        {
            await _categoryService.ICategoryRepositories.AddCategory(category);
            _categoryService.Save();
        }

        public async Task DeleteCategoryFromService(int category)
        {
            var x= await _categoryService.ICategoryRepositories.GetCategoryById(category);
            if (x == null)
            {
                throw new CategoryNotFoundExceptions(category);
            }
            await _categoryService.ICategoryRepositories.DeleteCategory(x);
            _categoryService.Save();


        }

        public async Task<IEnumerable<Category>> GetAllCategories(bool v)
        {
            return await _categoryService.ICategoryRepositories.GetAllCategories(v);
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryService.ICategoryRepositories.GetCategoryById(id);
        }

        public async Task UpdateCategoryFromService(Category category)
        {
            var x = await _categoryService.ICategoryRepositories.GetCategoryById(category.CategoryID);
            if(x == null)
            {
                throw new CategoryNotFoundExceptions(category.CategoryID);
            }
            x.CategoryName = category.CategoryName;
            x.OwnProducts = category.OwnProducts;
            x.Products = category.Products;
            await _categoryService.ICategoryRepositories.UpdateCategory(category);
            _categoryService.Save();
            
        }
    }
}
