﻿using FluentValidation;
using MediatR;

namespace LinkBaseApi.Application.Shared.Behavior
{
	public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			if (!_validators.Any()) return await next();

			var context = new ValidationContext<TRequest>(request);

			if (_validators.Any())
			{
				context = new ValidationContext<TRequest>(request);
				var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
				var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

				if (failures.Count != 0)
				{
					throw new FluentValidation.ValidationException(failures);
				}
			}
			return await next();
		}
	}
}
