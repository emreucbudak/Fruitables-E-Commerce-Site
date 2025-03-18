using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Context 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Bills> Bills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<OwnProduct> OwnProducts { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<WeGives> WeGives { get; set; }
        public DbSet<City> Cities {  get; set; }
        public DbSet<Country> Countries { get; set; }

    }
}
