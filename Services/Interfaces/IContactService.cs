using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IContactService
    {
        Task AddContactFromService(ContactDto category);
        Task DeleteContactFromService(int category);
        Task<IEnumerable<ContactDto>> GetAllContact(bool v);
        Task<ContactDto> GetContact(int id);
        Task UpdateContactFromService(int id ,ContactDto category);
    }
}
