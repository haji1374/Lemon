using FluentValidation;

namespace Portal.Application.FoodApplication.Commands
{
    public class CreateFoodCommandValidator : AbstractValidator<CreateFoodCommand>
    {
        public CreateFoodCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Food should have a name.");
            RuleFor(u => u.Price).GreaterThan(0).WithMessage("Food can not be free.");
            RuleFor(u => u.Description).NotEmpty().WithMessage("Food needs description");
        }
    }
}