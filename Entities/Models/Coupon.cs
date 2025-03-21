﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        
        public DateOnly ExpDate { get; set; }
    }
}
