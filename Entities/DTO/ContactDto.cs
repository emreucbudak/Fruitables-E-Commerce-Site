using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public record ContactDto
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string Message { get; init; }
    }
}
