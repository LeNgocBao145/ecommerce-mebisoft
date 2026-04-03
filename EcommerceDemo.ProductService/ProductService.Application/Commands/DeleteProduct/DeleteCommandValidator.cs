using FluentValidation;

namespace ProductService.Application.Commands.DeleteProduct
{
    public class DeleteCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product Id must be greater than 0.");
        }
    }
}
