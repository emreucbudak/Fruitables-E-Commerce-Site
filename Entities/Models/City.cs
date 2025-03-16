using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int PostCode { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }

    }
}
