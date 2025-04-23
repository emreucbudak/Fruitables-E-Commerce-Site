using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public static class ProductExtensions
    {
        public static IQueryable<Products> FilterProducts(this IQueryable<Products> query, uint maxPrice, uint MinPrice) => query.Where(b=> b.Price <  maxPrice && b.Price > MinPrice);
        public static IQueryable<Products> SearchProducts(this IQueryable<Products> prdct, string ProductName)
        {
            if (!prdct.Any() || string.IsNullOrWhiteSpace(ProductName))
                return prdct;
            return prdct.Where(b => b.Name.ToLower().Trim().Contains(ProductName.Trim().ToLower()));
        }
        
    }
}
