using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public abstract record CommentDtoForManipulation
    {
        public int Ratio { get; init; }
        public string Text { get; init; }

    }
}
