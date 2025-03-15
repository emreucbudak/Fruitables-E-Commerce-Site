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

        public async Task<IEnumerable<Bills>> GetAllBills(bool v)
        {
            return await GetAll(v).ToListAsync();
        }

        public async Task<Bills> GetBillsByID(int id, bool v)
        {
            return await GetById(b=> b.Id == id,v);
        }

        public async Task UpdateBills(Bills bil)
        {
           await  Update(bil);
        }
    }
}
