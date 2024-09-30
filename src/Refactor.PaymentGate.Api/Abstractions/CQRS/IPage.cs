namespace Refactor.PaymentGate.Api.Abstractions.CQRS;

public interface IPage
{
    int PageSize { get; init; }
}