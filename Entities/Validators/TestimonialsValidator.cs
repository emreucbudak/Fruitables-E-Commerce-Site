using Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators
{
    public class TestimonialsValidator : AbstractValidator<TestimonialsDto>
    {
        public TestimonialsValidator()
        {
            // Name: boş olamaz, en az 2 karakter
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim boş olamaz.")
                .MinimumLength(2).WithMessage("İsim en az 2 karakter olmalıdır.");

            // Role: boş olamaz
            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Rol boş olamaz.");

            // ImgUrl: boş olamaz ve geçerli bir URL olmalı
            RuleFor(x => x.ImgUrl)
                .NotEmpty().WithMessage("Resim URL'si boş olamaz.")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("Geçerli bir URL giriniz.");

            // Ratio: 0 ile 5 arasında olmalı
            RuleFor(x => x.Ratio)
                .InclusiveBetween(0, 5)
                .WithMessage("Oran 0 ile 5 arasında olmalıdır.");

            // Comment: boş olamaz, en az 10 karakter olmalı
            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Yorum boş olamaz.")
                .MinimumLength(10).WithMessage("Yorum en az 10 karakter olmalıdır.");
        }
    }
}
