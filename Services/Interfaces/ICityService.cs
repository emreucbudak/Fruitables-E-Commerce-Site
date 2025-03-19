using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAll(bool v);
    }
}
