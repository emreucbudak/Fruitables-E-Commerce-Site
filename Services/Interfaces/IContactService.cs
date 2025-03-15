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
        Task AddContactFromService(Contact category);
        Task DeleteContactFromService(Contact category);
        Task<IEnumerable<Contact>> GetAllContact(bool v);
        Task<Contact> GetContact(int id);
        Task UpdateContactFromService(Contact category);
    }
}
