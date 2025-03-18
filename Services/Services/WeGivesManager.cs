using Entities.Exceptions;
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
            var x =  await _rp.weGivesRepositories.GetWeGives(id, v);
            if (x == null)
            {
                throw new WeGivesNotFoundExceptions(id);
            }
            return x;

        }

        public async Task RemoveWeGives(int weGives)
        {
            var x = await GetWeGives(weGives,false);
            await _rp.weGivesRepositories.RemoveWeGives(x);
            _rp.Save();
            
        }

        public async Task UpdateWeGives(WeGives wegs)
        {
            var x = await GetWeGives(wegs.Id, false);
            x.Title = wegs.Title;
            x.Description = wegs.Description;
            x.ImgUrl = wegs.ImgUrl;
            await _rp.weGivesRepositories.UpdateWeGives(x);
            _rp.Save();
        }
    }
}
