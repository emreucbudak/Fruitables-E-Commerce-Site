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
    public class StatsRepository : RepositoryBase<Stats>, IStatsRepositories
    {
        public StatsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddStats(Stats stats)
        {
            await Add(stats);
        }

        public async Task DeleteStats(Stats stats)
        {
            await Delete(stats);
        }

        public async Task<IEnumerable<Stats>> GetAllStats(bool v)
        {
            return await GetAll(v).ToListAsync();
        }

        public async Task<Stats> GetStatsByID(int id, bool v)
        {
            return await GetById(b=> b.Id == id , v );
        }

        public async Task UpdateStats(Stats stats)
        {
            await Update(stats);
        }
    }
}
