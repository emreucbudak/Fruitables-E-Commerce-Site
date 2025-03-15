﻿using Entities.Models;
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
        Task<Products> GetProductsById(int id, bool v);
        Task<IEnumerable<Products>> GetAllProducts(bool v);
    }
}
