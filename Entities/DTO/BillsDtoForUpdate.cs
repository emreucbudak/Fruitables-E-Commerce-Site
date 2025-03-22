using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public record BillsDtoForUpdate
    {
        public string CompanyName { get; init; }
        public string Adress { get; init; }
        public string City { get; init; }
        public string Country { get; init; }
        public int PostCode { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get;  init; }
        public string OrderNotes { get; init; }
    }
}
