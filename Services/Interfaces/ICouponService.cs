using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICouponService
    {
        Task AddCouponFromService(Coupon cpn);
        Task UpdateCouponFromService(int id , Coupon cpn);
        Task DeleteCouponFromService(int cpn);
        Task<IEnumerable<Coupon>> GetAllCoupons(bool v);
        Task<Coupon> GetCoupons(int id , bool v);
    }
}
