using AutoMapper;
using Entities.DTO;
using Entities.Models;
using FruitablesAPI.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BillsManager : IBillsService
    {
        private readonly IRepositoryManager _rp;
        private readonly ILoggerService _lg;
        private readonly IMapper _mapper;

        public BillsManager(IRepositoryManager rp, ILoggerService _log, IMapper map)
        {
            _rp = rp;
            _lg = _log;
            _mapper = map;
        }

        public async Task AddBillsFromService(BillsDtoForInsert bil)
        {

            var x = _mapper.Map<Bills>(bil);
            await _rp.IBillsRepositories.AddBills(x);
            _rp.Save();
        }

        public async Task<IEnumerable<BillsDtoForList>> GetAllBillsFromService(bool v)
        {
           return   await _rp.IBillsRepositories.GetAllBills(v);
        }

        public async Task<BillsDtoForList> GetBillsFromService(int billsId)
        {
            var x =  await _rp.IBillsRepositories.GetBillsByID(billsId,false);
            if (x == null)
            {
                throw new BillsNotFoundExceptions(billsId);
            }
            return x;
        }

        public async Task<Bills> RemoveBillsFromService(int billsId)
        {
            var x = await GetBillsAndCheck(billsId);
            await _rp.IBillsRepositories.DeleteBills(x);
            _rp.Save();
            return x;

        }

        public async Task<Bills> UpdateBillsFromService(int id , BillsDtoForUpdate bills)
        {
            var x = await GetBillsAndCheck(id);

            x.FirstName = bills.FirstName;
            x.LastName = bills.LastName;
            x.Email = bills.Email;
            x.Adress = bills.Adress;
            x.PhoneNumber = bills.PhoneNumber;
            x.City = bills.City;
            x.Country = bills.Country;
            x.OrderNotes = bills.OrderNotes;
            x.PostCode = bills.PostCode;
            x.CompanyName = bills.CompanyName;
            await _rp.IBillsRepositories.UpdateBills(x);
            _rp.Save();
            return x;
        }
        private async Task<Bills> GetBillsAndCheck(int id)
        {
            var x = await _rp.IBillsRepositories.GetBillsAndCheck(id, false);
            if (x == null)
            {
                throw new BillsNotFoundExceptions(id);
            }
            return x;
            
        }
    }
}
