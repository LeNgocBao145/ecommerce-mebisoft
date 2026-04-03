using FluentValidation;
using ProductService.Application.Validators;

namespace ProductService.Application.Commands.CreateProduct
{
    public class CreateCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateCommandValidator()
        {
            Include(new ProductCommandValidator());
        }
    }
}
