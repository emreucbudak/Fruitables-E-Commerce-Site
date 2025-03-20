using AutoMapper;
using Entities.DTO;
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
        private readonly IMapper _mp;

        public CouponService(IRepositoryManager rp, IMapper mmp)
        {
            _rp = rp;
            _mp = mmp;
        }

        public async Task AddCouponFromService(CouponDto cpn)
        {


            var y = _mp.Map<Coupon>(cpn);


           
            await _rp.ICouponRepositories.AddCoupon(y);
            _rp.Save();
        }

        public async Task DeleteCouponFromService(int cpn)
        {
            var x = await GetCouponById(cpn);


            await _rp.ICouponRepositories.DeleteCoupon(x);
            _rp.Save();
        }

        public async Task<IEnumerable<CouponDto>> GetAllCoupons(bool v)
        {
            var x =  await _rp.ICouponRepositories.GetAllCoupons(v);
            var y = _mp.Map<IEnumerable<CouponDto>>(x);

            return y;
        }

        public async Task<CouponDto> GetCoupons(int id, bool v)
        {
            var x =  await _rp.ICouponRepositories.GetCouponById(id, v);
            if (x == null)
            {
                throw new CouponNotFoundExceptions(id);
            }
            var y = _mp.Map<CouponDto>(x);
            return y;
        }

        public async Task UpdateCouponFromService(int id , CouponDtoForUpdate cpn)
        {
            var x = await GetCouponById(id);
            x.Quantity = cpn.Quantity;

            x.ExpDate = cpn.ExpDate;
            await _rp.ICouponRepositories.UpdateCoupon(x);
            _rp.Save();
        }
        private async Task<Coupon> GetCouponById(int id)
        {
            var x = await _rp.ICouponRepositories.GetCouponById(id, false);
            if (x == null)
            {
                throw new CouponNotFoundExceptions(id);
            }
            return x;
        }
    }
}
