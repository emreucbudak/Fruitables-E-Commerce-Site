﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 15;
        public int PageNumber { get; set; }
        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set
            {
                pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public String? OrderBy { get; set; }
        
    }
}
