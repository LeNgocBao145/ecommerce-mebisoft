using FluentValidation;
using ProductService.Application.Validators;

namespace ProductService.Application.Commands.UpdateProduct
{
    public class UpdateCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required.");
            Include(new ProductCommandValidator());
        }
    }
}
