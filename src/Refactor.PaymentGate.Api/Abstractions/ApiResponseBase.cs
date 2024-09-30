namespace Refactor.PaymentGate.Api.Abstractions;

public class ApiResponseBase<TData>(int code, string message, TData data)
{
    public int Code { get; } = code;
    public string Message { get; } = message;
    public TData Data { get; } = data;
}
