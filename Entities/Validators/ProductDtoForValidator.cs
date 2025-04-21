using Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators
{
    public class ProductDtoForValidator : AbstractValidator<ProductDtoForManipulation>
    {
        public ProductDtoForValidator() {
            RuleFor(x => x.Name)
        .NotEmpty().WithMessage("İsim boş olamaz.")
        .MinimumLength(3).WithMessage("İsim en az 3 karakter olmalıdır.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.")
                .MinimumLength(5).WithMessage("Açıklama en az 5 karakter olmalıdır.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");

            RuleFor(x => x.Ratio)
                .InclusiveBetween(0, 5).WithMessage("Oran 0 ile 5 arasında olmalıdır.");

            RuleFor(x => x.Quentity)
                .GreaterThan(0).WithMessage("Adet 0'dan büyük olmalıdır.");

            RuleFor(x => x.ImgUrl)
                .NotEmpty().WithMessage("Resim URL'si boş olamaz.")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("Geçerli bir URL giriniz.");
        }
    }
}
