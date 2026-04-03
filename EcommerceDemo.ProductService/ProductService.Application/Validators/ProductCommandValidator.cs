using FluentValidation;
using ProductService.Application.Interfaces;

namespace ProductService.Application.Validators
{
    public class ProductCommandValidator : AbstractValidator<IProductCommand>
    {
        public ProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Product description must not exceed 500 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Product price must be greater than 0.");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Product stock must be greater than or equal to 0.");
        }
    }
}
