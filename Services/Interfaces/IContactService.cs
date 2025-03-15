using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IContactRepository
    {
        Task AddContactFromService(Contact category);
        Task DeleteCategoryFromService(Contact category);
        Task<IEnumerable<Contact>> GetAllCategories(bool v);
        Task<Contact> GetCategory(int id);
        Task UpdateCategoryFromService(Contact category);
    }
}
