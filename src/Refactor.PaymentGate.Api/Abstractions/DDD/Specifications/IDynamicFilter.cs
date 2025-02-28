namespace Refactor.PaymentGate.Api.Abstractions.DDD.Specifications;

public interface IDynamicFilter : IFilter
{
    IList<FilterByEntry> FilterProperties { get; init; }
    abstract static IReadOnlyCollection<string> AllowedFilterProperties { get; }
    abstract static IReadOnlyCollection<string> AllowedFilterOperations { get; }
}

public interface IDynamicFilter<TEntity> : IFilter<TEntity>, IDynamicFilter
    where TEntity : EntityBase
{
}
