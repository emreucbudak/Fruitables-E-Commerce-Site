using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class WeGivesNotFoundExceptions : NotFoundExceptions
    {
        public WeGivesNotFoundExceptions(int id) : base($"{id} e sahip servis bulunamadı!")
        {
        }
    }
}
