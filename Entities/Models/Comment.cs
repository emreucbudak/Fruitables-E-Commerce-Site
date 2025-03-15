using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int  Ratio { get; set; }
        public DateTime Date { get; set; }
        public string Text {  get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Products Products { get; set; }

    }
}
