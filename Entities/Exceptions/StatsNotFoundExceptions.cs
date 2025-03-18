using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class StatsNotFoundExceptions : NotFoundExceptions
    {
        public StatsNotFoundExceptions(int id) : base($"{id} li istatistik bulunamadı!")
        {
        }
    }
}
