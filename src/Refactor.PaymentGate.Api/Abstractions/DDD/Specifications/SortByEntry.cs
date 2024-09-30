namespace Refactor.PaymentGate.Api.Abstractions.DDD.Specifications;

public sealed record SortByEntry
{
    public required string PropertyName { get; init; }
    public required SortDirection SortDirection { get; init; }
    public required int SortPriority { get; init; }
}