namespace Refactor.PaymentGate.Api.Abstractions.CQRS;

public sealed class CursorPage : ICursorPage
{
    public required int PageSize { get; init; }
    public required string Cursor { get; init; }
}