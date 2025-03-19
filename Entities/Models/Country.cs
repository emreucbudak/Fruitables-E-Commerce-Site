using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        [JsonIgnore]
        public ICollection<City> Cities { get; set; }
    }
}
