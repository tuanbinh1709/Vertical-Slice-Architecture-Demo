namespace Refactor.PaymentGate.Api.Abstractions.DDD.Specifications;

public interface IFilter
{
}

public interface IFilter<TEntity> : IFilter
    where TEntity : class, IEntityBase
{
    IQueryable<TEntity> Apply(IQueryable<TEntity> queryable);
}