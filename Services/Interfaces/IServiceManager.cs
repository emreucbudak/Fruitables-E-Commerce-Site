using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IServiceManager
    {
        IBillsService BillsService { get; }
        ICartService CartService { get; }
        ICategoryService CategoryService { get; }
        ICommentService CommentService { get; }
        IContactService ContactService { get; } 
        ICouponService CouponService { get; }
        IOwnProductsService OwnProductsService { get; }
        IProductService ProductService { get; } 
        IStatsService StatsService { get; }
        IUserService UserService { get; }
        ITestimonialService TestimonialService { get; }
        IWeGivesService WeGivesService { get; }
        ICityService CityService { get; }
        ICountryService CountryService { get; }
    }
}
