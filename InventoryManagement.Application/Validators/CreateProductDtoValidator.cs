using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InventoryManagement.Application.DTOs;

namespace InventoryManagement.Application.Validators
{
    //for checking createproductdto
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            //rule1
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(150).WithMessage("Product name cannot exceed 150 characters.");

            //rule2
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            //rule3
            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative.");

            //rule4
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).When(x => x.CategoryId.HasValue).WithMessage("Invalid Category ID.");
        }
    }
}
