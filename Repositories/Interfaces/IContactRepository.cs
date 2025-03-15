using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task AddContact (Contact contact);
        Task UpdateContact (Contact contact);
        Task DeleteContact (Contact contact);
        Task<IEnumerable<Contact>> GetAllContacts (bool v);
        Task<Contact> GetContactById (int id,bool v);
    }
}
