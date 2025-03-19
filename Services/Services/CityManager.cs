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
    public class CityManager : ICityService
    {
        private readonly IRepositoryManager _rp;

        public CityManager(IRepositoryManager rp)
        {
            _rp = rp;
        }

        public async Task<IEnumerable<City>> GetAll(bool v)
        {
            return await _rp.cityRepository.GetAllCity(v);
        }
    }
}
