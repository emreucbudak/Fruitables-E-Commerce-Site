using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Interfaces;
using Repositories.Repositories;
using Services.Interfaces;
using Services.Services;

namespace FruitablesAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSql(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("FruitablesAPI")));

        }
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }
        public static void ConfigureRepositoryItems(this IServiceCollection services)
        {
            services.AddScoped<IBillsRepositories, BillsRepositories>();
            services.AddScoped<ICartRepositories, CartRepository>();
            services.AddScoped<ICategoryRepositories, CategoryRepository>();
            services.AddScoped<ICommentRepositories, CommentRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ICouponRepositories, CouponRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<IOwnProducts,OwnProductRepository>();
            services.AddScoped<IProductsRepositories, ProductRepository>();
            services.AddScoped<IStatsRepositories, StatsRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<IUserRepositories, UserRepository>();
            services.AddScoped<IWeGivesRepositories, WeGivesRepository>();

        }
        public static void ConfigureServiceItems(this IServiceCollection services)
        {
            services.AddScoped<IBillsService,BillsManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<ICouponService,CouponService>();
            services.AddScoped<IOwnProductsService,OwnProductsManager>();
            services.AddScoped<IProductService,ProductsManager>();
            services.AddScoped<IStatsService, StatsManager>();
            services.AddScoped<ITestimonialService,TestimonialManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IWeGivesService, WeGivesManager>();

        }
        public static void ConfigureLoggerService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ILoggerService,LoggerManager>();
        }


    }
}
