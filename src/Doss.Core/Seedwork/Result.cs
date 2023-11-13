using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace Doss.Core.Seedwork;

public enum ResultType
{
    Ok,
    NotFound,
    Error
}

public static class Parser
{
    public static void ParserToError(ValidationResult validationResult, List<Error> erros)
    {
        if (!validationResult.IsValid)
        {
            foreach (var fluentValidatorError in validationResult.Errors)
            {
                erros.Add(new Error(fluentValidatorError.PropertyName, fluentValidatorError.ErrorMessage));
            }
        }
    }

    public static Result ToResult(this ValidationResult validationResult)
    {
        var result = new Result();

        foreach (var fluentValidatorError in validationResult.Errors)
        {
            result.AddErro(new Error(fluentValidatorError.PropertyName, fluentValidatorError.ErrorMessage));
        }

        return Results.ToResult<Result>(result, result?.Errors);
    }
}

public class Result
{
    public string? Object { get; set; }

    public IEnumerable<Error>? Errors { get; private set; }

    public string? Message { get; set; }

    public bool Success => ResultType == ResultType.Ok;

    public void AddErros(IEnumerable<Error> errors)
        => Errors = errors;

    public void AddErro(Error error)
    {
        if (Errors is not {}) Errors = new List<Error>();
        ((List<Error>)Errors).Add(error);
    }

    [JsonIgnore]
    public ResultType ResultType { get; set; }
}

public class Result<T> : Result
{
    public T? Data { get; set; }
}

public static class Results
{
    private const string messageNotFound = "Não foi possivel encontrar o recurso.";
    private const string messageError = "Erro ao processar a requisição.";

    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>
        {
            Data = value
        };
    }

    public static Result<T> Ok<T>()
    {
        return new Result<T>();
    }

    public static Result Ok()
    {
        return new Result();
    }

    public static Result NotFound(string message = messageNotFound)
    {
        var resultado = new Result
        {
            ResultType = ResultType.NotFound,
            Message = message
        };

        return resultado;
    }

    public static Result<T> NotFound<T>(T value)
    {
        var resultado = new Result<T>
        {
            ResultType = ResultType.NotFound,
            Data = value
        };

        return resultado;
    }

    public static Result<T> NotFound<T>(string message = messageNotFound)
    {
        var resultado = new Result<T>
        {
            ResultType = ResultType.NotFound,
            Message = message
        };

        return resultado;
    }

    public static Result Error(string message = messageError)
    {
        var resultado = new Result
        {
            ResultType = ResultType.Error,
            Message = message
        };

        return resultado;
    }

    public static Result Error(IEnumerable<Error> errors, string message = messageError)
    {
        var resultado = new Result
        {
            ResultType = ResultType.Error,
            Message = message
        };

        if (errors != null)
            resultado.AddErros(errors);

        return resultado;
    }

    public static Result<T> Error<T>(IEnumerable<Error> errors, string message = messageError)
    {
        var resultado = new Result<T>
        {
            ResultType = ResultType.Error,
            Message = message
        };

        if (errors is { })
            resultado.AddErros(errors);

        return resultado;
    }

    public static Result<T> Error<T>(Error error, string message = messageError)
    {
        var resultado = new Result<T>
        {
            ResultType = ResultType.Error,
            Message = message
        };

        if (error is { })
            resultado.AddErro(error);

        return resultado;
    }

    public static Result<T> Error<T>(string message = messageError)
    {
        return new Result<T>
        {
            ResultType = ResultType.Error,
            Message = message
        };
    }

    public static Result ToResult<T>(T value, IEnumerable<Error>? Errors = null)
    {
        if (Errors is not { })
            return Ok<T>(value);

        return Error<T>(Errors);
    }

    public static Result<T> ToResult<T>(T value)
    {
        return Ok<T>(value);
    }
}

public class Error
{
    public int? Index { get; set; }
    public string Property { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;

    public Error(string property, string message)
        => (Property, Message) = (property, message);
}
