using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class OrderNotFoundExceptions : NotFoundExceptions
    {
        public OrderNotFoundExceptions(int id) : base($"{id} ' e sahip sipariş bulunamadı!")
        {
        }
    }
}
