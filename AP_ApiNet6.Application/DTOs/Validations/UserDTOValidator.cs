using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Application.DTOs.Validations
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.Email)
                 .NotEmpty()
                 .NotNull()
                 .WithMessage("Email deve ser informado!");

            RuleFor(x => x.Password)
                 .NotEmpty()
                 .NotNull()
                 .WithMessage("Password deve ser informado!");

        }
    }
}
