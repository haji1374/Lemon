using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Portal.Application.Common
{
    public class CommonValidationPipline<TRequest, TResponce> : IPipelineBehavior<TRequest, TResponce>
    {
        private readonly IList<IValidator<TRequest>> validators;

        public CommonValidationPipline(IList<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }
        public async Task<TResponce> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponce> next)
        {

            var errors = validators.Select(it => it.Validate(request))
                                   .SelectMany(it => it.Errors)
                                   .Where(error => error != null)
                                   .ToList();

            if (errors.Any())
            {
                var errorBuilder = new StringBuilder();

                errorBuilder.AppendLine("Invalid command, reason: ");

                foreach (var error in errors)
                {
                    errorBuilder.AppendLine(error.ErrorMessage);
                }

                throw new Exception(errorBuilder.ToString());
            }

            return await next.Invoke();
        }
    }
}