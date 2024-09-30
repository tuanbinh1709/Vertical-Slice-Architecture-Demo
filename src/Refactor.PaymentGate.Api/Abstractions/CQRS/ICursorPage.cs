namespace Refactor.PaymentGate.Api.Abstractions.CQRS;

public interface ICursorPage : IPage
{
    string Cursor { get; init; }
}
