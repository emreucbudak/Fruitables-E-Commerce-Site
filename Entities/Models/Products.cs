using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Ratio { get; set; }
        public int Quentity { get; set; }

        public bool IsExpired { get; set; }
        public bool IsDiscount {  get; set; }
        public string ImgUrl { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
