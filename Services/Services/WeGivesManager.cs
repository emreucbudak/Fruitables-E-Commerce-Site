﻿using Entities.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class WeGivesManager : IWeGivesService
    {
        private readonly IRepositoryManager _rp;

        public WeGivesManager(IRepositoryManager rp)
        {
            _rp = rp;
        }

        public async Task AddWeGives(WeGives wegs)
        {
            await _rp.weGivesRepositories.AddWeGives(wegs);
            _rp.Save();
        }

        public async Task<IEnumerable<WeGives>> GetAllWeGives(bool v)
        {
            return await _rp.weGivesRepositories.GetAllWeGives(v);
        }

        public async Task<WeGives> GetWeGives(int id, bool v)
        {
            return await _rp.weGivesRepositories.GetWeGives(id, v);
        }

        public async Task RemoveWeGives(WeGives weGives)
        {
            await _rp.weGivesRepositories.RemoveWeGives(weGives);
            _rp.Save();
        }

        public async Task UpdateWeGives(WeGives wegs)
        {
            await _rp.weGivesRepositories.UpdateWeGives(wegs);
            _rp.Save();
        }
    }
}
