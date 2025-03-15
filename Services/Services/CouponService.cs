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
    public class CouponService : ICouponService
    {
        private readonly IRepositoryManager _rp;

        public CouponService(IRepositoryManager rp)
        {
            _rp = rp;
        }

        public async Task AddCouponFromService(Coupon cpn)
        {
            await _rp.ICouponRepositories.AddCoupon(cpn);
            _rp.Save();
        }

        public async Task DeleteCouponFromService(Coupon cpn)
        {
            await _rp.ICouponRepositories.DeleteCoupon(cpn);
            _rp.Save();
        }

        public async Task<IEnumerable<Coupon>> GetAllCoupons(bool v)
        {
            return await _rp.ICouponRepositories.GetAllCoupons(v);

        }

        public async Task<Coupon> GetCoupons(int id, bool v)
        {
            return await _rp.ICouponRepositories.GetCouponById(id, v);
        }

        public async Task UpdateCouponFromService(Coupon cpn)
        {
            await _rp.ICouponRepositories.UpdateCoupon(cpn);
            _rp.Save();
        }
    }
}
