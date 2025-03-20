using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<CitiesDto>> GetAllCity(bool v);
    }
}
