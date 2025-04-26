using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Interfaces;
using Repositories.Repositories;
using Services.Interfaces;
using Services.Services;
using System.Reflection;
using System;
using Entities.DTO;
using Entities.Validators;
using Presentation.ActionFilters;
using AspNetCoreRateLimit;

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
            services.AddScoped<Services.Interfaces.IServiceManager, ServiceManager>();
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

        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(); // Otomatik validasyon desteği
            services.AddFluentValidationClientsideAdapters(); // İstemci tarafı validasyon desteği

            // Tüm Validatorları bulup otomatik olarak ekler
            services.AddValidatorsFromAssembly(Assembly.Load("Entities"));
            services.AddScoped<IValidator<UserDtoForManipulation>, UserValidator>();
            services.AddValidatorsFromAssemblyContaining<UserValidator>();
        }
        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddSingleton<LogFilterAttribute>();
        }
        public static void ConfigureResponseCache (this IServiceCollection services)
        {
            services.AddResponseCaching();
        }
        public static void ConfigureRateLimit(this IServiceCollection services)
        {
            var limitRules = new List<RateLimitRule>()
    {
        new RateLimitRule()
        {
            Endpoint = "*",
            Period = "1m",
            Limit = 3
        }
    };
            services.Configure<IpRateLimitOptions>(opt =>
            {
                opt.GeneralRules = limitRules;
            });
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        }
        public static void ApplyCors (this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", builder =>
                {
                    builder.WithOrigins("https://www.frontend.com")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .WithExposedHeaders("X-Pagination"); 
                });
            });
        }


    }
}
