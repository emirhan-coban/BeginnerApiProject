using BeginnerApiProject.WebApi.Entities;
using FluentValidation;

namespace BeginnerApiProject.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product name cannot be empty.");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Product name must be at least 2 characters long.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }
}
