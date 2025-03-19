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

        public async Task DeleteStats(int stats)
        {
             var x = await GetStatsById(stats,false);

             await _statsService.statsRepositories.DeleteStats(x);
            _statsService.Save();
        }

        public async Task<IEnumerable<Stats>> GetStats(bool v)
        {
            return await _statsService.statsRepositories.GetAllStats(v);
        }

        public async Task<Stats> GetStatsById(int id, bool v)
        {
            var x =  await _statsService.statsRepositories.GetStatsByID(id, v);
            if (x == null)
            {
                throw new StatsNotFoundExceptions(id);
            }
            return x;
        }

        public async Task UpdateStats(int id , Stats stats)
        {
            var x =  await GetStatsById(id, false);

            x.Title = stats.Title;
            x.ImgUrl = stats.ImgUrl;
            x.Count = stats.Count;
            await _statsService.statsRepositories.UpdateStats(x);
            _statsService.Save();
        }
    }
}
