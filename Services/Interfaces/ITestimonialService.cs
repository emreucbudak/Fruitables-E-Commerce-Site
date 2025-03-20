using Entities.DTO;
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
        Task AddTestimonial(TestimonialsDto testimonials);
        Task UpdateTestimonial(int id , TestimonialsDto testimonials);
        Task DeleteTestimonial(int testimonials);
        Task<IEnumerable<TestimonialsDto>> GetTestimonials(bool v);
        Task <TestimonialsDto> GetTestimonialss(int id,bool v);
    }
}
