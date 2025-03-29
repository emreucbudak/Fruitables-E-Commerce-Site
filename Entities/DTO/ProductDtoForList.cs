using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public sealed record ProductDtoForList : ProductDtoForManipulation
    {
        public string CategoryName { get; init; }
    }
}
