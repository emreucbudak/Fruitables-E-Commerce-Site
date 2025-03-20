using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IWeGivesService
    {
        Task AddWeGives(WeGivesDto wegs);
        Task RemoveWeGives(int weGives);
        Task UpdateWeGives(int id , WeGivesDto wegs);
        Task<IEnumerable<WeGives>> GetAllWeGives(bool v);
        Task<WeGives> GetWeGives(int id ,bool v);
    }
}
