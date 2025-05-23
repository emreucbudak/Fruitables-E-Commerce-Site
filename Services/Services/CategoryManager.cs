﻿using Entities.Exceptions;
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
        private readonly ILoggerService _logg;

        public CategoryManager(IRepositoryManager categoryService,ILoggerService _lg)
        {
            _categoryService = categoryService;
            _logg = _lg;
        }

        public async Task AddCategoryFromService(Category category)
        {
            await _categoryService.ICategoryRepositories.AddCategory(category);
            _categoryService.Save();
        }

        public async Task DeleteCategoryFromService(int category)
        {
            var x = await GetCategoryById(category);
            await _categoryService.ICategoryRepositories.DeleteCategory(x);
            _categoryService.Save();


        }

        public async Task<IEnumerable<Category>> GetAllCategories(bool v)
        {
            return await _categoryService.ICategoryRepositories.GetAllCategories(v);
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var x=  await _categoryService.ICategoryRepositories.GetCategoryById(id);
            if (x == null)
            {
                throw new CategoryNotFoundExceptions(id);
            }
            return x;
        }

        public async Task UpdateCategoryFromService(int id , Category category)
        {
            var x = await GetCategoryById(id); 
            x.CategoryName = category.CategoryName;
            x.OwnProducts = category.OwnProducts;
            x.Products = category.Products;
            await _categoryService.ICategoryRepositories.UpdateCategory(x);
            _categoryService.Save();
            
        }
    }
}
