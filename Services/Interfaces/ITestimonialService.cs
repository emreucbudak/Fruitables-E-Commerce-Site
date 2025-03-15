using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITestimonialService
    {
        Task AddTestimonial(Testimonials testimonials);
        Task UpdateTestimonial(Testimonials testimonials);
        Task DeleteTestimonial(Testimonials testimonials);
        Task<IEnumerable<Testimonials>> GetTestimonials(bool v);
        Task <Testimonials> GetTestimonials(int id,bool v);
    }
}
