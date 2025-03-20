using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public record CitiesDto
    {
        public string CityName { get; init; }
        public string PostCode { get; init; }
        public string CountryName { get; init; }
    }
}
