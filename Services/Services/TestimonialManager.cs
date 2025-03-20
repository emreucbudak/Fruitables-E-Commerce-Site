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
    public class TestimonialManager : ITestimonialService
    {
        private readonly IRepositoryManager _rp;
        private readonly IMapper _mapper;

        public TestimonialManager(IRepositoryManager rp , IMapper mp)
        {
            _rp = rp;
            _mapper = mp;
        }

        public async Task AddTestimonial(TestimonialsDto testimonials)
        {
            var x = _mapper.Map<Testimonials>(testimonials);
            await _rp.testimonial.AddTestimonial(x);
            _rp.Save();
        }

        public async Task DeleteTestimonial(int testimonials)
        {
            var x = await CheckTestimonials(testimonials);

            await _rp.testimonial.DeleteTestimonial(x);
        }

        public async Task<IEnumerable<TestimonialsDto>> GetTestimonials(bool v)
        {
            var x =  await _rp.testimonial.GetAllTestimonials(v);
            var y = _mapper.Map<IEnumerable<TestimonialsDto>>(x);
            return y;
        }



        public async Task<TestimonialsDto> GetTestimonialss(int id, bool v)
        {
            var x =  await _rp.testimonial.GetTestimonial(id, v);    
            if (x == null)
            {
                throw new TestimonialNotFoundExceptions(id);
            }
            var y = _mapper.Map<TestimonialsDto>(x);
            return y;
        }

        public async Task UpdateTestimonial(int id , TestimonialsDto testimonials)
        {
            var x = await CheckTestimonials(id);

            x.Ratio = testimonials.Ratio;
            x.Comment = testimonials.Comment;
            await _rp.testimonial.UpdateTestimonial(x);
            _rp.Save();
        }
        private async Task <Testimonials> CheckTestimonials(int id)
        {
            var x = await _rp.testimonial.GetTestimonial(id,false);
            if (x == null)
            {
                throw new TestimonialNotFoundExceptions(id);
            }
            return x;
        }
    }
}
