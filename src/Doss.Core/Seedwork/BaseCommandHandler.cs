using FluentValidation;
using MediatR;

namespace Doss.Core.Seedwork;

public abstract class BaseCommandHandler<TCommand, TCommandValidator> : IRequestHandler<TCommand, Result>
       where TCommand : Command
       where TCommandValidator : AbstractValidator<TCommand>
{
    private readonly TCommandValidator validator;

    protected BaseCommandHandler(TCommandValidator validator)
    {
        this.validator = validator;
    }

    public abstract Task<Result> HandleImplementation(TCommand command);

    public async Task<Result> Handle(TCommand command, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(command);

        if (!validationResult.IsValid)
            return validationResult.ToResult();

        return await HandleImplementation(command);

    }
}

public abstract class BaseCommandHandler<TCommand, TCommandValidator, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : Command<TResponse>
    where TCommandValidator : AbstractValidator<TCommand>
{
    private readonly TCommandValidator validator;

    protected BaseCommandHandler(TCommandValidator validator)
    {
        this.validator = validator;
    }

    public abstract Task<Result<TResponse>> HandleImplementation(TCommand request);

    public async Task<Result<TResponse>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
            return Results.Error<TResponse>(validationResult.ToResult().Errors!);

        return await HandleImplementation(request);

    }
}