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
    public class CouponRepository : RepositoryBase<Coupon>, ICouponRepositories
    {
        public CouponRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddCoupon(Coupon coupon)
        {
            await Add(coupon);
        }

        public async Task DeleteCoupon(Coupon coupon)
        {
            await Delete(coupon);
        }

        public async Task<IEnumerable<Coupon>> GetAllCoupons(bool v)
        {
            return await GetAll(v).ToListAsync();
        }

        public async Task<Coupon> GetCouponById(int couponId, bool v)
        {
            return await GetById(b=> b.Id == couponId, v);
        }

        public async Task UpdateCoupon(Coupon coupon)
        {
            await Update(coupon);
        }
    }
}
