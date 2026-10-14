using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.Products.Commands
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product Name is Required.")
                .MaximumLength(100).WithMessage("Product Name must not exceed 100 characters.");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater Than Zero");
        }
    }
}
