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
        Task UpdateTestimonial(int id , Testimonials testimonials);
        Task DeleteTestimonial(int testimonials);
        Task<IEnumerable<Testimonials>> GetTestimonials(bool v);
        Task <Testimonials> GetTestimonialss(int id,bool v);
    }
}
