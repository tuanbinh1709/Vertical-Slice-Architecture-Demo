namespace Refactor.PaymentGate.Api.Abstractions.Results;

public static class HttpResultExtensions
{
    public static ProblemHttpResult ToBadRequest<TResponse>(this IResult<TResponse> result)
    where TResponse : IResponse
    {
        return result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException("Result was successful"),

            IValidationResult validationResult =>
                TypedResults
                    .Problem(title: ValidationError,
                        statusCode: StatusCodes.Status400BadRequest,
                        type: result.Error.Code,
                        detail: result.Error.Message,
                        extensions: validationResult.ToDictionary()
                    ),

            _ => TypedResults
                .Problem(title: InvalidRequest,
                    statusCode: StatusCodes.Status400BadRequest,
                    type: result.Error.Code
            )
        };
    }

    public static Ok<TResponse> ToOk<TResponse>(this IResult<TResponse> result)
        where TResponse : IResponse
    {
        return TypedResults.Ok(result.Value);
    }

    public static ProblemHttpResult ToNotFound<TResponse>(this IResult<TResponse> result)
        where TResponse : IResponse
    {
        return result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException("Result was successful"),

            IValidationResult validationResult =>
                TypedResults
                    .Problem(title: ValidationError,
                        statusCode: StatusCodes.Status404NotFound,
                        type: result.Error.Code,
                        detail: result.Error.Message,
                        extensions: validationResult.ToDictionary()
                    ),

            _ => TypedResults
                .Problem(title: InvalidRequest,
                    statusCode: StatusCodes.Status404NotFound,
                    type: result.Error.Code
            )
        };
    }

    public static Created<TResponse> ToCreated<TResponse>(this IResult<TResponse> result, string? routeName = null)
        where TResponse : ICreatedResponse
    {
        return TypedResults.Created($"{routeName}/{result.Value.Id}", result.Value);
    }
}
