using MediatR;
using Portal.Common.Enums;
using Portal.Domain.Common;

namespace Portal.Application.FoodApplication.Commands.Edit
{
    public class EditFoodCommand : IRequest<int>
    {
        public int Id { get; set; }
        public Money Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FoodType FoodType { get; set; }
    }
}