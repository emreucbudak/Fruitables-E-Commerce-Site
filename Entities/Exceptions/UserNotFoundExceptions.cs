using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class UserNotFoundExceptions : NotFoundExceptions
    {
        public UserNotFoundExceptions(int id) : base($"{id} e sahip user yok!")
        {
        }
    }
}
