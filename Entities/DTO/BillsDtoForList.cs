using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public sealed record BillsDtoForList : BillsDtoForManipulation
    {

        public string UserName { get; init; }
        public string CreatedAt { get; init; }

    }
}
