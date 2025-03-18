using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStatsService
    {
        Task AddStats(Stats stats);
        Task UpdateStats(Stats stats);
        Task DeleteStats(int stats);
        Task<IEnumerable<Stats>> GetStats(bool v);
        Task<Stats> GetStatsById(int id , bool v);
    }
}
