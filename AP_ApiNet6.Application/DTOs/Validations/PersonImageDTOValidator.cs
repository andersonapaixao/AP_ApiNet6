using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Application.DTOs.Validations
{
    public class PersonImageDTOValidator : AbstractValidator<PersonImageDTO>
    {
        public PersonImageDTOValidator()
        {
            RuleFor(x => x.PersonId)
               .GreaterThanOrEqualTo(0)
               .WithMessage("PersonId não pode ser menor ou igual a zero!");

            RuleFor(x => x.Image)
                .NotEmpty()
                .NotNull()
                .WithMessage("Image deve ser informado!");
        }
    }
}
