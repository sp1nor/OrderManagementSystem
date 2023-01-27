using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ordering.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators,
                                  ILogger<ValidationBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle
        (
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken
        )
        {
            if (_validators.Any())
            {
                string typeName = request.GetType().Name;
                _logger.LogInformation("Validating command {CommandType}", typeName);

                ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);
                var validationResults = await
                    Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults.SelectMany(_result => _result.Errors)
                    .Where(error => error != null).ToList();

                if (failures.Any())
                {
                    _logger.LogInformation(
                        "Validation errors - {CommandType} - Command: {@Command} - Errors: {@ValidationErrors}",
                        typeName, request, failures);
                }
            }

            return await next();
        }
    }
}
