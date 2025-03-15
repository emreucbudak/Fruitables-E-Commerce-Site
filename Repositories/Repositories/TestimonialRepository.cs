using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class TestimonialRepository : RepositoryBase<Testimonials>, ITestimonialRepository
    {
        public TestimonialRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddTestimonial(Testimonials testimonials)
        {
            await Add(testimonials);
        }

        public async Task DeleteTestimonial(Testimonials testimonials)
        {
            await Delete(testimonials);
        }

        public async Task<IEnumerable<Testimonials>> GetAllTestimonials(bool v)
        {
            return await GetAll(v).ToListAsync();
        }

        public async Task<Testimonials> GetTestimonial(int id, bool v)
        {
            return await GetById(b => b.Id == id, v);
        }

        public async Task UpdateTestimonial(Testimonials testimonials)
        {
            await Update(testimonials);
        }
    }
}
