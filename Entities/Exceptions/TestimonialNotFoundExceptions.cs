using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class TestimonialNotFoundExceptions : NotFoundExceptions
    {
        public TestimonialNotFoundExceptions(int id) : base($"{id} e sahip görüş yok!")
        {
        }
    }
}
