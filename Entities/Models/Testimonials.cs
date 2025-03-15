using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Testimonials
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string ImgUrl { get; set; }
        public int Ratio { get; set; }
        public string Comment { get; set; }
    }
}
