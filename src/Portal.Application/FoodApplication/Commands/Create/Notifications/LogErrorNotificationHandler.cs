using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Portal.Application.FoodApplication.Commands.Create.Notifications
{
    public class LogErrorNotificationHandler : INotificationHandler<CreateFoodCommandNotification>
    {
        private readonly ILogger<LogErrorNotificationHandler> logger;
        public LogErrorNotificationHandler(ILogger<LogErrorNotificationHandler> logger)
        {
            this.logger = logger;
        }

        public Task Handle(CreateFoodCommandNotification notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("=================================================================================================================================");
            logger.LogInformation(DateTime.Now.ToString());
            logger.LogWarning(Thread.GetCurrentProcessorId().ToString());
            logger.LogError(notification.Message);
            logger.LogInformation("=================================================================================================================================");
            return Task.CompletedTask;
        }
    }

}