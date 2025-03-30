using Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators
{
    public class BillsValidator : AbstractValidator<BillsDtoForManipulation>
    {
        public BillsValidator() {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim Kısmı Boş Olamaz")
                .MinimumLength(2).WithMessage(" ad Minimum 2 karakter olmalı");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim kısmı boş olamaz")
                .MinimumLength(2).WithMessage(" soyad minimum 2 karakter olmalı");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email Boş Olamaz")
                .EmailAddress().WithMessage("Yanlış Eposta Formatı")
                .Matches(@"^[A-Za-z0-9._%+-]+@(gmail\.com|outlook\.com|hotmail\.com)$").WithMessage("EMAİL İÇİN GEÇERLİ UZANTILAR GMAİL HOTMAİL OUTLOOKDUR");
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("şirket kısmı boş olamaz")
                .MinimumLength(9).WithMessage("şirket minimum 9 karakter olmalı");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Geçerli bir telefon numarası giriniz.");


        }
    }
}
