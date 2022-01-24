using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Portal.Application.FoodApplication.Commands.Create.Notifications
{
    public class LogDebugNotificationHandler : INotificationHandler<CreateFoodCommandNotification>
    {
        private readonly ILogger<LogDebugNotificationHandler> logger;
        public LogDebugNotificationHandler(ILogger<LogDebugNotificationHandler> logger)
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