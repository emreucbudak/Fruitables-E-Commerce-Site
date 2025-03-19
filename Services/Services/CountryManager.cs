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
    public class CountryManager : ICountryService
    {
        private readonly IRepositoryManager _rp;

        public CountryManager(IRepositoryManager rp)
        {
            _rp = rp;
        }

        public async Task<IEnumerable<Country>> GetAll(bool v)
        {
            return await _rp.countryRepository.GetAllCountry(v);
        }
    }
}
