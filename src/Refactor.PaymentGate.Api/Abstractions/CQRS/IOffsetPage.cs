namespace Refactor.PaymentGate.Api.Abstractions.CQRS;

public interface IOffsetPage : IPage
{
    int PageNumber { get; init; }
}
