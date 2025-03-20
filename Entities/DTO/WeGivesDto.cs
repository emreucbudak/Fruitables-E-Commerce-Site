﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public record WeGivesDto
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public string ImgUrl { get; init; }
    }
}
