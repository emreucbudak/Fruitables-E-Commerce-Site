using AutoMapper;
using Entities.DTO;
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
        private readonly IMapper _mp;

        public WeGivesManager(IRepositoryManager rp,IMapper map)
        {
            _rp = rp;
            _mp = map;

        }

        public async Task AddWeGives(WeGivesDto wegs)
        {
            if (wegs == null)
            {
                throw new WeGivesNotFoundExceptions(1);
            }
            var x = _mp.Map<WeGives>(wegs);
            await _rp.weGivesRepositories.AddWeGives(x);
            _rp.Save();
        }

        public async Task<IEnumerable<WeGivesDto>> GetAllWeGives(bool v)
        {
            var x =  await _rp.weGivesRepositories.GetAllWeGives(v);
            var y = _mp.Map<IEnumerable<WeGivesDto>>(x);
            return y;
        }

        public async Task<WeGivesDto> GetWeGives(int id, bool v)
        {
            var x =  await _rp.weGivesRepositories.GetWeGives(id, v);
            if (x == null)
            {
                throw new WeGivesNotFoundExceptions(id);
            }
            var y = _mp.Map<WeGivesDto>(x);
            return y;

        }

        public async Task RemoveWeGives(int weGives)
        {
            var x = await GetWeGivesByIdAsnyc(weGives);
            await _rp.weGivesRepositories.RemoveWeGives(x);
            _rp.Save();
            
        }

        public async Task UpdateWeGives(int id , WeGivesDto wegs)
        {
            var x = await GetWeGivesByIdAsnyc(id);
            x.Title = wegs.Title;
            x.Description = wegs.Description;
            x.ImgUrl = wegs.ImgUrl;
            await _rp.weGivesRepositories.UpdateWeGives(x);
            _rp.Save();
        }
        private async Task<WeGives> GetWeGivesByIdAsnyc(int id)
        {
            var x = await _rp.weGivesRepositories.GetWeGives(id,false);
            if (x == null)
            {
                throw new WeGivesNotFoundExceptions(id);
            }
            return x;
        }
        }
}
