using Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators
{
    public class ContactDtoForManipulation : AbstractValidator<ContactDto>
    {
        public ContactDtoForManipulation()
        {
            RuleFor(c => c.Name)
    .NotEmpty().WithMessage("İsim boş olamaz.")
    .MinimumLength(2).WithMessage("İsim en az 2 karakter olmalıdır.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(c => c.Message)
                .NotEmpty().WithMessage("Mesaj boş olamaz.")
                .MinimumLength(3).WithMessage("Mesaj en az 10 karakter olmalıdır.");
        }
    }
}
