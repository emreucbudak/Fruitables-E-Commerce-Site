using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public abstract record ProductDtoForManipulation
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public int Price { get; init; }
        public int Ratio { get; init; }
        public int Quentity { get; init; }

        public bool IsExpired { get; init; }
        public bool IsDiscount { get; init ; }
        public string ImgUrl { get; init; }

    }
}
