using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public record TestimonialsDto
    {
        public string Name { get; init; }
        public string Role { get; init; }
        public string ImgUrl { get; init; }
        public int Ratio { get; init; }
        public string Comment { get; init; }
    }
}
