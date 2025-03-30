using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public abstract record BillsDtoForManipulation
    {


        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string CompanyName { get; init; }
        public string Adress { get; init; }
        public string City { get; init; }
        public string Country { get; init; }
        public int PostCode { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }
        public string OrderNotes { get; init; }
    }
}
