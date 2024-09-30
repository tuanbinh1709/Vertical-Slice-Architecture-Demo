using Refactor.PaymentGate.Api.Abstractions.DDD.Specifications;

namespace Refactor.PaymentGate.Api.Abstractions.CQRS;

public interface IOffsetPageQuery<TResponse, TFilter, TSortBy, TPage> : IOffsetPageQuery<TResponse, TPage>
    where TResponse : IResponse
    where TFilter : IFilter
    where TSortBy : ISortBy
    where TPage : IOffsetPage
{
    TFilter? Filter { get; }
    TSortBy? SortBy { get; }
}

public interface IOffsetPageQuery<TResponse, TPage> : IPageQuery<OffsetPageResponse<TResponse>, TPage>
    where TResponse : IResponse
    where TPage : IOffsetPage
{
}
