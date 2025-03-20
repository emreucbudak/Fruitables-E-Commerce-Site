using AutoMapper;
using Entities.DTO;
using Entities.Models;

namespace FruitablesAPI.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeGivesDto, WeGives>();
        }
    }
}
