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

        public BillsManager(IRepositoryManager rp,ILoggerService _log)
        {
            _rp = rp;
            _lg = _log;
        }

        public async Task AddBillsFromService(Bills bil)
        {
            await _rp.IBillsRepositories.AddBills(bil);
            _rp.Save();
        }

        public async Task<IEnumerable<Bills>> GetAllBillsFromService(bool v)
        {
           return  await _rp.IBillsRepositories.GetAllBills(v);
        }

        public async Task<Bills> GetBillsFromService(int billsId)
        {
            return await _rp.IBillsRepositories.GetBillsByID(billsId,false);
        }

        public async Task<Bills> RemoveBillsFromService(int billsId)
        {
            var x = await _rp.IBillsRepositories.GetBillsByID(billsId,false );
            if (x == null)
            {
                throw new BillsNotFoundExceptions(billsId);
            }
            await _rp.IBillsRepositories.DeleteBills(x);
            _rp.Save();
            return x;

        }

        public async Task<Bills> UpdateBillsFromService(Bills bills)
        {
            var x = await _rp.IBillsRepositories.GetBillsByID(bills.Id, false);
            if (x == null)
            {
                throw new BillsNotFoundExceptions(bills.Id);
            }
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
    }
}
