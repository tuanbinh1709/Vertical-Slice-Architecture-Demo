using Refactor.PaymentGate.Api.Abstractions.DDD.Specifications;

namespace Refactor.PaymentGate.Api.Abstractions.CQRS;

public interface ICursorPageQuery<TResponse, TFilter, TSortBy, TPage> : ICursorPageQuery<TResponse, TPage>
    where TResponse : IResponse
    where TFilter : IFilter
    where TSortBy : ISortBy
    where TPage : ICursorPage
{
    TFilter? Filter { get; }
    TSortBy? SortBy { get; }
}

public interface ICursorPageQuery<TResponse, TPage> : IPageQuery<CursorPageResponse<TResponse>, TPage>
    where TResponse : IResponse
    where TPage : ICursorPage
{
}
