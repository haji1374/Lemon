using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Portal.Application.Common
{
    public class CommonPiplineLogging<TRequest, TResponce> : IPipelineBehavior<TRequest, TResponce>
    {
        private readonly ILogger<CommonPiplineLogging<TRequest, TResponce>> logger;

        public CommonPiplineLogging(ILogger<CommonPiplineLogging<TRequest, TResponce>> logger)
        {
            this.logger = logger;
        }

        public async Task<TResponce> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponce> next)
        {
            logger.LogWarning($"Befor Handel {request.GetType().ToString()}");
            var responce = await next.Invoke();
            logger.LogWarning($"After Handel {responce.GetType().ToString()}");

            return responce;
        }
    }
}