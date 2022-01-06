using System.Collections.Generic;
using MediatR;
using Portal.Application.Foods.Models;

namespace Portal.Application.FoodApplication.Query.FindAll
{
    public class FindAllFoodQuery : IRequest<IList<FoodInfo>>
    {

    }
}