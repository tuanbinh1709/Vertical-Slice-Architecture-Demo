namespace Refactor.PaymentGate.Api.Abstractions.CQRS;

public sealed record OffsetPage : IOffsetPage
{
    public required int PageSize { get; init; }
    public required int PageNumber { get; init; }
}