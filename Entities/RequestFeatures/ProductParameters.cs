using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        

        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = 1000;
        public bool Control => MinPrice < MaxPrice;
        public String? ProductName { get; set; }

        public String? Category {  get; set; }
        public bool? IsDiscount {  get; set; }
    }
}
