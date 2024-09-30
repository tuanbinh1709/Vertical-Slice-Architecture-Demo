namespace Refactor.PaymentGate.Api.Abstractions.DDD.Specifications;

public interface ISortBy
{
}

public interface ISortBy<TEntity> : ISortBy
    where TEntity : class, IEntityBase
{
    IQueryable<TEntity> Apply(IQueryable<TEntity> queryable);
}