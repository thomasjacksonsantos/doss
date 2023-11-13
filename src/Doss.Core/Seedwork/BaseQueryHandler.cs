using FluentValidation;
using MediatR;

namespace Doss.Core.Seedwork;

public abstract class BaseQueryHandler<TQuery, TResult, TQueryValidator> : IRequestHandler<TQuery, Result<TResult>>
    where TQuery : Query<TResult>
    where TQueryValidator : AbstractValidator<TQuery>
{
    private readonly TQueryValidator validator;

    protected BaseQueryHandler(TQueryValidator validator)
    {
        this.validator = validator;
    }

    public abstract Task<Result<TResult>> HandleImplementation(TQuery query);

    public async Task<Result<TResult>> Handle(TQuery query, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(query);

        if (!validationResult.IsValid)
            return Results.Error<TResult>(validationResult.ToResult().Errors!);

        return await HandleImplementation(query);
    }
}

