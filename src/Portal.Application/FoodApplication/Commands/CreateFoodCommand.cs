using MediatR;
using Portal.Common.Enums;

namespace Portal.Application.FoodApplication.Commands
{
    public class CreateFoodCommand : IRequest<int>
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FoodType FoodType { get; set; }
    }
}