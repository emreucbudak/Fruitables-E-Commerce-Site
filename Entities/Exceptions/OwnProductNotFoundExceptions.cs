using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class OwnProductNotFoundExceptions : NotFoundExceptions
    {
        public OwnProductNotFoundExceptions(int id) : base($"{id} 'e sahip ürün bulunamadı!")
        {
        }
    }
}
