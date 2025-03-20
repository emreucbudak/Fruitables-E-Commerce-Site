using AutoMapper;
using Entities.DTO;
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
        private readonly IMapper _mp;

        public CountryManager(IRepositoryManager rp,IMapper mp)
        {
            _rp = rp;
            _mp = mp;
        }

        public async Task<IEnumerable<CountriesDto>> GetAll(bool v)
        {
            var x =  await _rp.countryRepository.GetAllCountry(v);
            var y = _mp.Map<IEnumerable<CountriesDto>>(x);
            return y;

        }
    }
}
