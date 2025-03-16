using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class ContactNotFoundExceptions : NotFoundExceptions
    {
        public ContactNotFoundExceptions(int id ) : base($"{id} ' e sahip talep bulunamadı!")
        {
        }
    }
}
