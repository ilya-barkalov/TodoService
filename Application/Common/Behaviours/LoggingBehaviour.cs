﻿using MediatR.Pipeline;

using Microsoft.Extensions.Logging;

using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> 
        where TRequest : notnull
    {
        private readonly ILogger _logger;

        public LoggingBehaviour(ILogger<TRequest> logger) 
            => _logger = logger;

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Request: {Name} {@Request}", typeof(TRequest).Name, request);

            await Task.CompletedTask;
        }
    }
}
