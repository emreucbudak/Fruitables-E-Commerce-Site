using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddContact(Contact contact)
        {
            await Add(contact);
        }

        public async Task DeleteContact(Contact contact)
        {
            await Delete(contact);
        }

        public async Task<IEnumerable<Contact>> GetAllContacts(bool v)
        {
            return await GetAll(v).ToListAsync();
        }

        public async Task<Contact> GetContactById(int id, bool v)
        {
            return await GetById(b=> b.Id == id, v);
        }

        public async Task UpdateContact(Contact contact)
        {
            await Update(contact);
        }
    }
}
