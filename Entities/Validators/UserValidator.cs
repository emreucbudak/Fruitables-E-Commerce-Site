using Entities.DTO;
using Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators
{
    public class UserValidator : AbstractValidator<UserDtoForManipulation>
    {
        public UserValidator() {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email Boş Olamaz")
                .EmailAddress().WithMessage("Yanlış Eposta Formatı")
                .Matches(@"^[A-Za-z0-9._%+-]+@(gmail\.com|outlook\.com|hotmail\.com)$").WithMessage("EMAİL İÇİN GEÇERLİ UZANTILAR GMAİL HOTMAİL OUTLOOKDUR");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre Alanı boş bırakılamaz.")
                .MinimumLength(6).WithMessage("şifre en az 6 karakter olmalı.")
                .Matches(@"[A-Z]").WithMessage("şifre en az bir büyük harf içermeli.")
                .Matches(@"[a-z]").WithMessage("şifre en az bir küçük harf içermeli.")
                .Matches(@"[0-9]").WithMessage("şifre e naz bir rakam içermeli.")
                .Matches(@"[\W_]").WithMessage("şifre en az bir özel karakter içermeli.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad Alanı boş bırakılamaz")
                .MinimumLength(2).WithMessage("şifre en az 2 karakter olmalı.");
        }
    }
}
