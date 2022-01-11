using FluentValidation;

namespace Portal.Application.FoodApplication.Commands.Create
{
    public class CreateFoodCommandValidator : AbstractValidator<CreateFoodCommand>
    {
        public CreateFoodCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Food should have a name.");
            RuleFor(u => u.Price.Value).GreaterThan(0).WithMessage("Food can not be free.");
            RuleFor(u => u.Description).NotEmpty().WithMessage("Food needs description");
        }
    }
}