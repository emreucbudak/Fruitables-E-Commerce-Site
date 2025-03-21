﻿using Entities.DTO;
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
    public class CityRepository : RepositoryBase<City>,ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CitiesDto>> GetAllCity(bool v)
        {
            return await GetAll(v)
                .Include(c => c.Country)
                .Select(c => new CitiesDto
                {
                    CityName = c.CityName,
                    PostCode = c.PostCode,
                    CountryName = c.Country.CountryName 
                })
                .ToListAsync();
        }
    }
}
