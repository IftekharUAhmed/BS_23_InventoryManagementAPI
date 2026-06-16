using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InventoryManagement.Application.DTOs;

namespace InventoryManagement.Application.Validators
{
    public class CreateSupplierDtoValidator : AbstractValidator<CreateSupplierDto>
    {
        public CreateSupplierDtoValidator()
        {
            //rule1
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Supplier name is required.")
                .MaximumLength(150).WithMessage("Supplier name cannot exceed 150 characters.");

            //rule2
            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("Invalid email format.");
        }
    }
}