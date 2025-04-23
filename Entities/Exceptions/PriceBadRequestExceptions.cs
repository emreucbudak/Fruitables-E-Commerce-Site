using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class PriceBadRequestExceptions : BadRequestExceptions
    {
        public PriceBadRequestExceptions() : base("Deger aralıgı yanlis")
        {
        }
    }
}
