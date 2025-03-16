using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CartNotFoundExceptions : NotFoundExceptions
    {
        public CartNotFoundExceptions(int id) : base($"{id}' e sahip sepet bulunamadı!")
        {
        }
    }
}
