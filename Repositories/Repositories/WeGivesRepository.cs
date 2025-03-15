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
    public class WeGivesRepository : RepositoryBase<WeGives>, IWeGivesRepositories
    {
        public WeGivesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddWeGives(WeGives wegs)
        {
            await Add(wegs);
        }

        public async Task<IEnumerable<WeGives>> GetAllWeGives(bool v)
        {
            return await GetAll(v).ToListAsync();
        }

        public async Task<WeGives> GetWeGives(int id, bool v)
        {
            return await GetById(b => b.Id == id , v);
        }

        public async Task RemoveWeGives(WeGives wegs)
        {
            await Delete(wegs);
        }

        public async Task UpdateWeGives(WeGives wegs)
        {
            await Update(wegs);
        }
    }
}
