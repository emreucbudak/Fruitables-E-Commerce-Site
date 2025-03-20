using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public record CouponDtoForUpdate
    {
        public int Quantity { get; init; }
        public DateOnly ExpDate { get; init; }
    }
}
