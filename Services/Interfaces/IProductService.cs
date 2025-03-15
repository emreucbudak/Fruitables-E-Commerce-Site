﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public  interface IProductService
    {
        Task AddProductFromService(Products prd);
        Task DeleteProductFromService(Products prd);
        Task UpdateProductFromService(Products prd);
        Task<IEnumerable<Products>> GetAllProducts(bool v);
        Task<Products> GetProductById(int id , bool v);

    }
}
