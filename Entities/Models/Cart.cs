﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        // sepet

    }
}
