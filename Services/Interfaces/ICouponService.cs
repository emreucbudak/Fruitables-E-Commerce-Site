using Entities.DTO;
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
        Task AddCouponFromService(CouponDto cpn);
        Task UpdateCouponFromService(int id , CouponDtoForUpdate cpn);
        Task DeleteCouponFromService(int cpn);
        Task<IEnumerable<CouponDto>> GetAllCoupons(bool v);
        Task<CouponDto> GetCoupons(int id , bool v);
    }
}
