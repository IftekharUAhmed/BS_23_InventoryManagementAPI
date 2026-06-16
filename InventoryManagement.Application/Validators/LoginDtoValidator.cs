using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InventoryManagement.Application.DTOs;

namespace InventoryManagement.Application.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            //rule1
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username cannot be empty.");

            //rule2
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty.");
        }
    }
}
