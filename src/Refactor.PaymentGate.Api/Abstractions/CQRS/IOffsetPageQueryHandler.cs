namespace Refactor.PaymentGate.Api.Abstractions.CQRS;

public interface IOffsetPageQueryHandler<TQuery, TResponse, TFilter, TSortBy, TPage> : IOffsetPageQueryHandler<TQuery, TResponse, TPage>
    where TQuery : IOffsetPageQuery<TResponse, TFilter, TSortBy, TPage>
    where TResponse : IResponse
    where TFilter : IFilter
    where TSortBy : ISortBy
    where TPage : IOffsetPage
{
}

public interface IOffsetPageQueryHandler<TQuery, TResponse, TPage> : IQueryHandler<TQuery, OffsetPageResponse<TResponse>>
    where TQuery : IOffsetPageQuery<TResponse, TPage>
    where TResponse : IResponse
    where TPage : IOffsetPage
{
}
