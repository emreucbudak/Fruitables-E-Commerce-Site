using AutoMapper;
using Entities.DTO;
using Entities.Exceptions;
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
        private readonly IMapper _mapper;
        public ContactManager(IRepositoryManager contactService, IMapper mp)
        {
            _contactService = contactService;
            _mapper = mp;
        }

        public async Task AddContactFromService(Contact category)
        {
            await _contactService.IContactRepository.AddContact(category);
            _contactService.Save();
        }

        public async Task DeleteContactFromService(int category)
        {
            var x= await GetContact(category);
            await _contactService.IContactRepository.DeleteContact(x);
            _contactService.Save();
        }

        public async Task<IEnumerable<ContactDto>> GetAllContact(bool v)
        {
            var x = await _contactService.IContactRepository.GetAllContacts(v);
            var y = _mapper.Map<IEnumerable<ContactDto>>(x);
            return y;
        }

        public async Task<Contact> GetContact(int id)
        {
            var x = await _contactService.IContactRepository.GetContactById(id,false);
            if (x == null)
            {
                throw new ContactNotFoundExceptions(id);
            }
            return x;
        }

        public async Task UpdateContactFromService(int id , Contact category)
        {
            var x = await GetContact(id);
            x.Email = category.Email;
            x.Name = category.Name;
            x.Message = category.Message;
            await _contactService.IContactRepository.UpdateContact(category);
            _contactService.Save();
        }
    }
}
