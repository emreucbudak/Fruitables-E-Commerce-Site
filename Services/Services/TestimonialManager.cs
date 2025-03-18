﻿using Entities.Exceptions;
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

        public TestimonialManager(IRepositoryManager rp)
        {
            _rp = rp;
        }

        public async Task AddTestimonial(Testimonials testimonials)
        {
            await _rp.testimonial.AddTestimonial(testimonials);
            _rp.Save();
        }

        public async Task DeleteTestimonial(int testimonials)
        {
            var x = await _rp.testimonial.GetTestimonial(testimonials,false);
            if (x == null)
            {
                throw new TestimonialNotFoundExceptions(testimonials);
            }
            await _rp.testimonial.DeleteTestimonial(x);
        }

        public async Task<IEnumerable<Testimonials>> GetTestimonials(bool v)
        {
            return await _rp.testimonial.GetAllTestimonials(v);
        }

        public async Task<Testimonials> GetTestimonials(int id, bool v)
        {
            return await _rp.testimonial.GetTestimonial(id, v);    
        }

        public async Task UpdateTestimonial(Testimonials testimonials)
        {
            var x = await _rp.testimonial.GetTestimonial(testimonials.Id, false);
            if (x == null)
            {
                throw new TestimonialNotFoundExceptions(testimonials.Id);
            }
            x.Ratio = testimonials.Ratio;
            x.Comment = testimonials.Comment;
            await _rp.testimonial.UpdateTestimonial(x);
            _rp.Save();
        }
    }
}
