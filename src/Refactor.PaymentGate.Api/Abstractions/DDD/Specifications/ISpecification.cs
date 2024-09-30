using System.Linq.Expressions;

namespace Refactor.PaymentGate.Api.Abstractions.DDD.Specifications;

public interface ISpecification<TEntity>
    where TEntity : class, IEntityBase
{
    // Tag
    string? QueryTag { get; }

    //Flags
    bool AsSplitQuery { get; }

    bool AsNoTracking { get; }

    bool AsTracking { get; }

    bool AsNoTrackingWithIdentityResolution { get; }

    bool UseGlobalFilters { get; }

    //Filter
    IFilter<TEntity>? Filter { get; }
    List<Expression<Func<TEntity, bool>>> FilterExpressions { get; }

    //SortBy
    (Expression<Func<TEntity, object>> SortBy, SortDirection SortDirection)? SortByExpression { get; }
    (Expression<Func<TEntity, object>> SortBy, SortDirection SortDirection)? ThenByExpression { get; }

    //Includes
    List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
    Func<IQueryable<TEntity>, IQueryable<TEntity>>? IncludeAction { get; }
}
