using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IWeGivesRepositories
    {
        Task AddWeGives(WeGives wegs);
        Task RemoveWeGives(WeGives wegs);
        Task UpdateWeGives (WeGives wegs);
        Task<IEnumerable<WeGives>> GetAllWeGives(bool v);
        Task<WeGives> GetWeGives(int id ,bool v);
    }
}
