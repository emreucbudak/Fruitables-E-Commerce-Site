using Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators
{
    class CommentDtoForManipulationValidator : AbstractValidator<CommentDtoForManipulation>
    {
        public CommentDtoForManipulationValidator()
        {
            RuleFor(c => c.Ratio)
    .InclusiveBetween(0, 5)
    .WithMessage("Ratio değeri 0 ile 5 arasında olmalıdır.");

            RuleFor(c => c.Text)
                .NotEmpty().WithMessage("Yorum metni boş olamaz.")
                .MinimumLength(3).WithMessage("Yorum metni en az 3 karakter olmalıdır.")
                .MaximumLength(200).WithMessage("Yorum metni en fazla 200 karakter olabilir.");
        }
    }
}
