﻿using AutoMapper;
using Entities.DTO;
using Entities.Models;

namespace FruitablesAPI.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeGivesDto, WeGives>();
            CreateMap<Country,CountriesDto>();
            CreateMap<City,CitiesDto>();
            CreateMap<Contact,ContactDto>();
            CreateMap<ContactDto,Contact>();
            CreateMap<CouponDto, Coupon>();
            CreateMap<Coupon,CouponDto>();
            CreateMap<WeGives, WeGivesDto>();
            CreateMap<Testimonials,TestimonialsDto>();
            CreateMap<TestimonialsDto,Testimonials>();  

        }
    }
}
