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
        Task<IEnumerable<WeGivesDto>> GetAllWeGives(bool v);
        Task<WeGivesDto> GetWeGives(int id ,bool v);
    }
}
