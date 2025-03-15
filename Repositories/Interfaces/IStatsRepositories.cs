using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IStatsRepositories
    {
        Task AddStats(Stats stats);
        Task UpdateStats(Stats stats);
        Task DeleteStats(Stats stats);
        Task<IEnumerable<Stats>> GetAllStats(bool v);
        Task<Stats> GetStatsByID(int id , bool v);
    }
}
