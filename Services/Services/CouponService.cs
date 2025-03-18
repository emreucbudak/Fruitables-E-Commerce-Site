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

        public async Task DeleteCouponFromService(int cpn)
        {
            var x = await GetCoupons(cpn, false);


            await _rp.ICouponRepositories.DeleteCoupon(x);
            _rp.Save();
        }

        public async Task<IEnumerable<Coupon>> GetAllCoupons(bool v)
        {
            return await _rp.ICouponRepositories.GetAllCoupons(v);

        }

        public async Task<Coupon> GetCoupons(int id, bool v)
        {
            var x =  await _rp.ICouponRepositories.GetCouponById(id, v);
            if (x == null)
            {
                throw new CouponNotFoundExceptions(id);
            }
            return x;
        }

        public async Task UpdateCouponFromService(Coupon cpn)
        {
            var x = await GetCoupons(cpn.Id , false);
            x.Quantity = cpn.Quantity;
            x.Discount = cpn.Discount;
            x.ExpDate = cpn.ExpDate;
            x.Code = cpn.Code;
            await _rp.ICouponRepositories.UpdateCoupon(x);
            _rp.Save();
        }
    }
}
