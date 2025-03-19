using Repositories.Context;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<IBillsRepositories> _billsRepositories;
        private readonly Lazy<ICartRepositories> _cartsRepositories;
        private readonly Lazy<ICategoryRepositories> _categoriesRepositories;
        private readonly Lazy<ICommentRepositories> _commentRepositories;
        private readonly Lazy<IContactRepository> _contactRepository;
        private readonly Lazy<ICouponRepositories> _couponRepositories;
        private readonly Lazy<IOwnProducts> _own;
        private readonly Lazy<IProductsRepositories> _products;
        private readonly Lazy<IStatsRepositories> _statsRepositories;
        private readonly Lazy<ITestimonialRepository> _estimonialRepository;
        private readonly Lazy<IUserRepositories> _userRepositories;
        private readonly Lazy<IWeGivesRepositories> _wegsRepositories;
        private readonly Lazy<ICityRepository> _cityRepository; 
        private readonly Lazy<ICountryRepository> _countryRepository;


        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _billsRepositories = new Lazy<IBillsRepositories>(() => new BillsRepositories(_context));
            _cartsRepositories = new Lazy<ICartRepositories>(() => new CartRepository(_context));
            _categoriesRepositories = new Lazy<ICategoryRepositories>(() => new CategoryRepository(_context));
            _commentRepositories = new Lazy<ICommentRepositories>(() => new CommentRepository(_context));
            _contactRepository = new Lazy<IContactRepository>(() => new ContactRepository(_context));
            _couponRepositories = new Lazy<ICouponRepositories>(() => new CouponRepository(_context));
            _own = new Lazy<IOwnProducts>(() => new OwnProductRepository(_context));
            _products = new Lazy<IProductsRepositories>(() => new ProductRepository(_context));
            _statsRepositories = new Lazy<IStatsRepositories>(() => new StatsRepository(_context));
            _estimonialRepository = new Lazy<ITestimonialRepository>(() => new TestimonialRepository(_context));
            _userRepositories = new Lazy<IUserRepositories>(() => new UserRepository(_context));
            _wegsRepositories = new Lazy<IWeGivesRepositories>(() => new WeGivesRepository(_context));
            _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(_context));
            _countryRepository = new Lazy<ICountryRepository>(() => new CountriesRepository(_context));

        }

        public IBillsRepositories IBillsRepositories => _billsRepositories.Value;

        public ICartRepositories ICartRepositories => _cartsRepositories.Value;

        public ICategoryRepositories ICategoryRepositories => _categoriesRepositories.Value;

        public ICommentRepositories ICommentRepositories => _commentRepositories.Value;

        public IContactRepository IContactRepository => _contactRepository.Value;

        public ICouponRepositories ICouponRepositories => _couponRepositories.Value;

        public IOwnProducts ownProducts => _own.Value;

        public IProductsRepositories products => _products.Value;

        public IStatsRepositories statsRepositories => _statsRepositories.Value;

        public ITestimonialRepository testimonial => _estimonialRepository.Value;

        public IUserRepositories userRepositories => _userRepositories.Value;

        public IWeGivesRepositories weGivesRepositories => _wegsRepositories.Value;

        public ICityRepository cityRepository => _cityRepository.Value;

        public ICountryRepository countryRepository => _countryRepository.Value;

        public  void Save()
        {
            _context.SaveChanges();
        }
    }
}
