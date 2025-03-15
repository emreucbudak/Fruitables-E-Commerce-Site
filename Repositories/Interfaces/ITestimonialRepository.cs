using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ITestimonialRepository
    {
        Task AddTestimonial(Testimonials testimonials);
        Task UpdateTestimonial(Testimonials testimonials);
        Task DeleteTestimonial(Testimonials testimonials);
        Task<IEnumerable<Testimonials>> GetAllTestimonials(bool v);
        Task<Testimonials> GetTestimonial(int id,bool v);
    }
}
