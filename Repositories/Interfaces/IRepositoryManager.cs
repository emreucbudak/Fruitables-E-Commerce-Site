using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRepositoryManager
    {
        IBillsRepositories IBillsRepositories { get; }
        ICartRepositories ICartRepositories { get; }
        ICategoryRepositories ICategoryRepositories { get; }
        ICommentRepositories ICommentRepositories { get; }
        IContactRepository IContactRepository { get; }
        ICouponRepositories ICouponRepositories { get; }
        IOwnProducts ownProducts { get; }
        IProductsRepositories products { get; }
        IStatsRepositories statsRepositories { get; }
        ITestimonialRepository testimonial { get; }
        IUserRepositories userRepositories { get; }
        IWeGivesRepositories weGivesRepositories { get; }

    }
}
