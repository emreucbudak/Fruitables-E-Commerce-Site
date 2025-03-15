using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICouponRepositories
    {
        Task AddCoupon (Coupon coupon);
        Task UpdateCoupon (Coupon coupon);
        Task DeleteCoupon (Coupon coupon);
        Task<Coupon> GetCouponById (int couponId,bool v);
        Task<IEnumerable<Coupon>> GetAllCoupons (bool v);
    }
}
