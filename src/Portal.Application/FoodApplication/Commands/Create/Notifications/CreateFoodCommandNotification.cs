using MediatR;
using Portal.Common.Enums;
using Portal.Domain.Common;

namespace Portal.Application.FoodApplication.Commands.Create.Notifications
{
    public class CreateFoodCommandNotification : INotification
    {
        public string Message { get; set; }
    }

}