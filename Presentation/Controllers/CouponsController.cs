using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Context;
using Services.Interfaces;
using Entities.DTO;
using Presentation.ActionFilters;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogFilterAttribute))]
    public class CouponsController : ControllerBase
    {
        private readonly IServiceManager _context;

        public CouponsController(IServiceManager context)
        {
            _context = context;
        }

        // GET: api/Coupons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CouponDto>>> GetCoupons()
        {
            var x = await  _context.CouponService.GetAllCoupons(false);
            return Ok(x);
        }

        // GET: api/Coupons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CouponDto>> GetCoupon(int id)
        {
            var x = await _context.CouponService.GetCoupons(id,false);
            return Ok(x);
        } 

        // PUT: api/Coupons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoupon(int id, CouponDtoForUpdate coupon)
        {
            await _context.CouponService.UpdateCouponFromService(id, coupon);

            return NoContent();
        }

        // POST: api/Coupons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<Coupon>> PostCoupon(CouponDto coupon)
        {
            await _context.CouponService.AddCouponFromService(coupon);
            return NoContent();
        }

        // DELETE: api/Coupons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _context.CouponService.DeleteCouponFromService(id);

            return NoContent();
        }
    }
}
