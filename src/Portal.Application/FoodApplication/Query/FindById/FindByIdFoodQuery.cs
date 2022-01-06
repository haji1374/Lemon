using MediatR;
using Portal.Application.Foods.Models;

namespace Portal.Application.FoodApplication.Query.FindById
{
    public class FindByIdFoodQuery : IRequest<FoodInfo>
    {
        public int id { get; set; }
    }
}