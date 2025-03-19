using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class CountriesRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountriesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Country>> GetAllCountry(bool v)
        {
            return await GetAll(v).ToListAsync();
        }
    }
}
