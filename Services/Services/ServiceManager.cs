using AutoMapper;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBillsService> _serviceProvider;
        private readonly Lazy<ICartService> _cartService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<ICommentService> _commentService;
        private readonly Lazy<IContactService> _contactService;
        private readonly Lazy<ICouponService> _couponService;
        private readonly Lazy<IOwnProductsService> _ownProductsService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IStatsService> _statsService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<ITestimonialService> testimonialService; 
        private readonly Lazy<IWeGivesService> weGivesService;
        private readonly Lazy<ICityService> cityService;
        private readonly Lazy<ICountryService> countryService;

        public ServiceManager(IRepositoryManager rp,ILoggerService _log,IMapper map)
        {
            _serviceProvider = new Lazy<IBillsService>(() => new BillsManager(rp,_log));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryManager(rp,_log));
            _commentService = new Lazy<ICommentService>(() => new CommentService(rp));
            _contactService = new Lazy<IContactService>(() => new ContactManager(rp,map));
            _couponService = new Lazy<ICouponService>(() => new CouponService(rp,map));
            _ownProductsService = new Lazy<IOwnProductsService>(() => new OwnProductsManager(rp));
            _productService = new Lazy<IProductService>(() => new ProductsManager(rp));
            _statsService = new Lazy<IStatsService>(() => new StatsManager(rp));
            _userService = new Lazy<IUserService>(() => new UserManager(rp));
            testimonialService = new Lazy<ITestimonialService>(() => new TestimonialManager(rp,map));
            weGivesService = new Lazy<IWeGivesService>(() => new WeGivesManager(rp,map));
            _cartService = new Lazy<ICartService>(() => new CartManager(rp));
            cityService = new Lazy<ICityService>(() => new CityManager(rp));
            countryService = new Lazy<ICountryService>(() => new CountryManager(rp,map));


        }

        public IBillsService BillsService => _serviceProvider.Value;

        public ICartService CartService => _cartService.Value;

        public ICategoryService CategoryService => _categoryService.Value;

        public ICommentService CommentService => _commentService.Value;

        public IContactService ContactService => _contactService.Value;

        public ICouponService CouponService => _couponService.Value;

        public IOwnProductsService OwnProductsService => _ownProductsService.Value;

        public IProductService ProductService => _productService.Value;

        public IStatsService StatsService => _statsService.Value;

        public IUserService UserService => _userService.Value;

        public ITestimonialService TestimonialService => testimonialService.Value;

        public IWeGivesService WeGivesService => weGivesService.Value;

        public ICityService CityService => cityService.Value;

        public ICountryService CountryService => countryService.Value;
    }
}
