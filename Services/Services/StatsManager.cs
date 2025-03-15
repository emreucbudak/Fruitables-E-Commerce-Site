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
    public class StatsManager : IStatsService
    {
        private readonly IRepositoryManager _statsService;
        public StatsManager(IRepositoryManager _rp)
        {
            _statsService = _rp;
        } 
        public async Task AddStats(Stats stats)
        {
           await  _statsService.statsRepositories.AddStats(stats);
            _statsService.Save();
        }

        public async Task DeleteStats(Stats stats)
        {
            await _statsService.statsRepositories.DeleteStats(stats);
            _statsService.Save();
        }

        public async Task<IEnumerable<Stats>> GetStats(bool v)
        {
            return await _statsService.statsRepositories.GetAllStats(v);
        }

        public async Task<Stats> GetStatsById(int id, bool v)
        {
            return await _statsService.statsRepositories.GetStatsByID(id, v);
        }

        public async Task UpdateStats(Stats stats)
        {
            await _statsService.statsRepositories.UpdateStats(stats);
        }
    }
}
