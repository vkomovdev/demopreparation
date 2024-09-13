using DietPreparation.Utilities.Validator;
using MediatR;

namespace DietPreparation.Application;

internal class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
	private readonly IValidationExecutor<TRequest> _validationExecutor;

	public ValidationBehavior(IValidationExecutor<TRequest> validationExecutor)
	{
		_validationExecutor = validationExecutor;
	}

	public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		_validationExecutor.Execute(request);
		return next();
	}
}