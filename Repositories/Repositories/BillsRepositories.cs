using Entities.DTO;
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
    public class BillsRepositories : RepositoryBase<Bills>, IBillsRepositories
    {
        public BillsRepositories(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddBills(Bills bil)
        {
            await Add(bil); 
            
        }

        public async Task DeleteBills(Bills bil)
        {
            await Delete(bil);
        }

        public async Task<IEnumerable<BillsDtoForList>> GetAllBills(bool v)
        {
            return await GetAll(v)
                .Include(c => c.User)
                .Select(c => new BillsDtoForList
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    UserName = c.User.Name,
                    CompanyName = c.CompanyName,
                    Adress = c.Adress,
                    City = c.City,
                    Country = c.Country,
                    PostCode = c.PostCode,
                    PhoneNumber = c.PhoneNumber,
                    Email = c.Email,
                    OrderNotes = c.OrderNotes,
                    CreatedAt = c.CreatedAt.ToString("dd.MM.yyyy HH:mm")
                }).ToListAsync();
        }

        public async Task<Bills> GetBillsAndCheck(int id, bool v)
        {
            return await GetById(b=> b.Id == id, v);
        }

        public async Task<BillsDtoForList> GetBillsByID(int id, bool v)
        {
            return await GetAll(v)
                .Where(b => b.Id == id)
                .Include(b => b.User)
                .Select(b => new BillsDtoForList
                {
                    FirstName = b.FirstName,
                    LastName = b.LastName,
                    UserName = b.User.Name,
                    CompanyName = b.CompanyName,
                    Adress = b.Adress,
                    City = b.City,
                    Country = b.Country,
                    PostCode = b.PostCode,
                    PhoneNumber = b.PhoneNumber,
                    Email = b.Email,
                    OrderNotes = b.OrderNotes
                })
                .FirstOrDefaultAsync();
        }

        public async Task UpdateBills(Bills bil)
        {
           await  Update(bil);
        }
    }
}
