namespace Refactor.PaymentGate.Api.Abstractions.Results;

public static class ResultExtensions
{
    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, Error error)
    {
        if (result.IsFailure)
        {
            return result;
        }

        return result.IsSuccess && predicate(result.Value) ? result : Result.Failure<T>(error);
    }

    public static Result<TOut> Map<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> func) =>
        result.IsSuccess ? func(result.Value) : Result.Failure<TOut>(result.Error);

    /// <summary>
    /// Send the <see cref="ICommand"/>, <see cref="ICommand{TResponse}"/> or <see cref="IQuery{TResponse}"/> to the corresponding handler.
    /// </summary>
    /// <typeparam name="TIn">Type of <see cref="ICommand"/>, <see cref="ICommand{TResponse}"/> or <see cref="IQuery{TResponse}"/>.</typeparam>
    /// <param name="result">The result.</param>
    /// <param name="func">The send function. Typically, this function is <see cref="Mediator.Send{TResponse}(IRequest{TResponse}, CancellationToken)"/>, <see cref="Mediator.Send{TRequest}(TRequest, CancellationToken)"/>.</param>
    /// <returns></returns>
    public static async Task<IResult> CallHandler<TIn>(this IResult<TIn> result, Func<TIn, Task<IResult>> func) =>
        result.IsSuccess ? await func(result.Value) : Result.Failure(result.Error);

    /// <summary>
    /// Send the <see cref="ICommand"/>, <see cref="ICommand{TResponse}"/> or <see cref="IQuery{TResponse}"/> to the corresponding handler.
    /// </summary>
    /// <typeparam name="TIn">Type of <see cref="ICommand"/>, <see cref="ICommand{TResponse}"/> or <see cref="IQuery{TResponse}"/>.</typeparam>
    /// <typeparam name="TResponse">The class implement the <see cref="IResponse"/>.</typeparam>
    /// <param name="result">The result.</param>
    /// <param name="func">The send function. Typically, this function is <see cref="Mediator.Send{TResponse}(IRequest{TResponse}, CancellationToken)"/>, <see cref="Mediator.Send{TRequest}(TRequest, CancellationToken)"/>.</param>
    /// <returns></returns>
    public static async Task<IResult<TResponse>> CallHandler<TIn, TResponse>(this IResult<TIn> result, Func<TIn, Task<IResult<TResponse>>> func) =>
        result.IsSuccess ? await func(result.Value) : Result.Failure<TResponse>(result.Error);

    /// <summary>
    /// Mapping the value or errors of the result of the newly created commands to the <see cref="IHttpResult"/>.
    /// </summary>
    /// <typeparam name="TResponse">The class implement the <see cref="IResponse"/>.</typeparam>
    /// <param name="resultTask">The result task.</param>
    /// <param name="routeName">The route of <typeparamref name="TResponse"/> resources.</param>
    /// <returns></returns>
    public static async Task<IHttpResult> HandleCreated<TResponse>(this Task<IResult<TResponse>> resultTask, string routeName)
        where TResponse : ICreatedResponse
    {
        IResult<TResponse> result = await resultTask;

        return result.IsSuccess ? result.ToCreated(routeName) : result.ToBadRequest();
    }

    /// <summary>
    /// Mapping the value or errors of the result of the queries to the <see cref="IHttpResult"/>.
    /// </summary>
    /// <typeparam name="TResponse">The class implement the <see cref="IResponse"/>.</typeparam>
    /// <param name="resultTask">The result task.</param>
    /// <returns></returns>
    public static async Task<IHttpResult> HandleGet<TResponse>(this Task<IResult<TResponse>> resultTask)
        where TResponse : IResponse
    {
        IResult<TResponse> result = await resultTask;

        return result.IsSuccess ? result.ToOk() : result.ToNotFound();
    }

    /// <summary>
    /// Mapping the value or errors of the result of the update or delete commands to the <see cref="IHttpResult"/>.
    /// </summary>
    /// <typeparam name="TResponse">The class implement the <see cref="IResponse"/>.</typeparam>
    /// <param name="resultTask">The result task.</param>
    /// <returns></returns>
    public static async Task<IHttpResult> HandleNotCreated<TResponse>(this Task<IResult<TResponse>> resultTask)
        where TResponse : IResponse
    {
        IResult<TResponse> result = await resultTask;

        return result.IsSuccess ? result.ToOk() : result.ToBadRequest();
    }
}
