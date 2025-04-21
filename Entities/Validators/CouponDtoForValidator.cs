using Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators
{
    public class CouponDtoForValidator : AbstractValidator<CouponDto>
    {
        public CouponDtoForValidator()
        {
            RuleFor(c => c.Code)
    .NotEmpty().WithMessage("Kupon kodu boş olamaz.")
    .MinimumLength(3).WithMessage("Kupon kodu en az 3 karakter olmalıdır.");

            RuleFor(c => c.Discount)
                .GreaterThan(0).WithMessage("İndirim oranı 0'dan büyük olmalıdır.");

            RuleFor(c => c.Quantity)
                .GreaterThan(0).WithMessage("Adet miktarı 0'dan büyük olmalıdır.");

            RuleFor(c => c.ExpDate)
                .Must(expDate => expDate >= DateOnly.FromDateTime(DateTime.Today))
                .WithMessage("Son kullanma tarihi geçmiş olamaz.");
        }
    }
}
