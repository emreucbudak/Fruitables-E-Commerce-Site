using Entities.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ContactManager : IContactService
    {
        private readonly IRepositoryManager _contactService;

        public ContactManager(IRepositoryManager contactService)
        {
            _contactService = contactService;
        }

        public async Task AddContactFromService(Contact category)
        {
            await _contactService.IContactRepository.AddContact(category);
            _contactService.Save();
        }

        public async Task DeleteContactFromService(Contact category)
        {
            await _contactService.IContactRepository.DeleteContact(category);
            _contactService.Save();
        }

        public async Task<IEnumerable<Contact>> GetAllContact(bool v)
        {
            return await _contactService.IContactRepository.GetAllContacts(v);
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _contactService.IContactRepository.GetContactById(id,false);
        }

        public async Task UpdateContactFromService(Contact category)
        {
            await _contactService.IContactRepository.UpdateContact(category);
            _contactService.Save();
        }
    }
}
