using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR.Pipeline;
using Portal.Persisatance;

namespace Portal.Application.Common
{
    public class CommonCommitPostProcessorPipline<TRequest, TResponce> : IRequestPostProcessor<TRequest, TResponce> where TRequest : IDisposable
    {
        private readonly PortalDbContext db;

        public CommonCommitPostProcessorPipline(PortalDbContext db)
        {
            this.db = db;
        }

        public async Task Process(TRequest request, TResponce response, CancellationToken cancellationToken)
        {
            await db.SaveChangesAsync();
        }
    }
}