using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InventoryManagement.Application.DTOs;

namespace InventoryManagement.Application.Validators
{
    public class StockTransactionDtoValidator : AbstractValidator<StockTransactionDto>
    {
        public StockTransactionDtoValidator()
        {
            //rule1
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID is required.");

            //rule2
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Transaction quantity must be greater than zero.");
        }
    }
}
