using FluentValidation;

namespace Portal.Application.FoodApplication.Commands.Edit
{
    public class EditFoodCommandValidation : AbstractValidator<EditFoodCommand>
    {
        public EditFoodCommandValidation()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Food should have a name.");
            RuleFor(u => u.Price.Value).GreaterThan(0).WithMessage("Food can not be free.");
            RuleFor(u => u.Description).NotEmpty().WithMessage("Food needs description");
        }
    }
}