using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BuildingBlocks.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var ValidationResult=
                await Task.WhenAll(validators.Select(x=>x.ValidateAsync(context,cancellationToken)));
            var Failures=
                ValidationResult
                .Where(x=>x.Errors.Any())
                .SelectMany(x=>x.Errors)
                .ToList();
            if (Failures.Any())
                throw new ValidationException(Failures);
            return await next();
        }
    }
}
