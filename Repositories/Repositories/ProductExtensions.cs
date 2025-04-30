using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repositories.Repositories
{
    public static class ProductExtensions
    {
        public static IQueryable<Products> FilterProducts(this IQueryable<Products> query, uint maxPrice, uint MinPrice) => query.Where(b => b.Price < maxPrice && b.Price > MinPrice);
        public static IQueryable<Products> SearchProducts(this IQueryable<Products> prdct, string ProductName)
        {
            if (string.IsNullOrWhiteSpace(ProductName))
                return prdct;
            var lowercase = ProductName.Trim().ToLower();
            prdct= prdct.Where(b => b.Name.ToLower().Contains(lowercase));
            return prdct;
        }
        public static IQueryable<Products> OrderProducts(this IQueryable<Products> prdct, string orderBy)
        {
            if(!prdct.Any())
            {
                return null;

            }
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return prdct.OrderBy(b => b.Name);
            }
            var prms = orderBy.Trim().Split(',');
            var propinfo = typeof(Products).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();
            foreach (var p in prms)
            {
                if(string.IsNullOrWhiteSpace(p))
                {
                    continue;
                }
                var prm = p.Split(' ')[0];
                var prt = propinfo.FirstOrDefault(pi => pi.Name.Equals(prm,StringComparison.InvariantCultureIgnoreCase));
                if (prt == null)
                {
                    continue;
                }
                var sorting = (prm.EndsWith(" desc")) ? "descending" : "ascending";
                sb.Append($"{prt.Name.ToString()} {sorting},");


            }
            var prts = sb.ToString().TrimEnd(',',' ');
            if (!prts.Any()) {
                prdct  =  prdct.OrderBy(prdct => prdct.Name);
                return prdct;

            }
            return prdct.OrderBy(prts);
            


        }

    }
}
