﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public sealed record BillsDtoForInsert : BillsDtoForManipulation
    {


        public int UserID { get; init; }

    }
}
