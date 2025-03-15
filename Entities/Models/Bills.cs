using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Bills
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Adress {  get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OrderNotes { get; set; }
        public int UserID { get; set; }

        public User User { get; set; }
    }
}
