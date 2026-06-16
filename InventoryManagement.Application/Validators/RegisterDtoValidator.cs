using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InventoryManagement.Application.DTOs;

namespace InventoryManagement.Application.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            //rule1
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters.");

            //rule2
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.");

            //rule3
            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required.")
                .Must(role => role == "Admin" || role == "Manager" || role == "Viewer")
                .WithMessage("Role must be strictly Admin, Manager, or Viewer.");
        }
    }
}
