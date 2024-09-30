namespace Refactor.PaymentGate.Api.Abstractions.DDD.Specifications;

internal static class SpecificationUtilities
{
    internal static SpecificationWithMapping<TEntity, TResponse> AsMappingSpecification<TEntity, TResponse>(this Specification<TEntity> specification)
        where TEntity : class, IEntityBase
    {
        return (SpecificationWithMapping<TEntity, TResponse>)specification;
    }

    internal static IQueryable<TEntity> UseSpecification<TEntity>(this IQueryable<TEntity> queryable, Specification<TEntity> specification)
        where TEntity : class, IEntityBase
    {
        if (specification.IncludeAction is not null)
        {
            queryable = specification.IncludeAction(queryable);
        }

        foreach (var includeExpression in specification.IncludeExpressions)
        {
            queryable = queryable.Include(includeExpression);
        }

        if (specification.FilterExpressions.NotNullOrEmpty())
        {
            foreach (var filter in specification.FilterExpressions)
            {
                queryable = queryable.Where(filter);
            }
        }

        if (specification.Filter is not null)
        {
            queryable = specification.Filter.Apply(queryable);
        }

        if (specification.SortBy is not null)
        {
            queryable = specification.SortBy.Apply(queryable);
        }

        if (specification.SortByExpression is not null and var sort)
        {
            queryable = queryable.OrderBy(sort.Value.SortBy, sort.Value.SortDirection);

            if (specification.ThenByExpression is not null and var then)
            {
                queryable = ((IOrderedQueryable<TEntity>)queryable).ThenBy(then.Value.SortBy, then.Value.SortDirection);
            }
        }

        if (specification.QueryTag is not null)
        {
            queryable = queryable.TagWith(specification.QueryTag);
        }

        if (specification.AsSplitQuery)
        {
            queryable = queryable.AsSplitQuery();
        }

        if (specification.AsNoTracking)
        {
            queryable = queryable.AsNoTracking();
        }

        if (specification.AsTracking)
        {
            queryable = queryable.AsTracking();
        }

        if (specification.AsNoTrackingWithIdentityResolution)
        {
            queryable = queryable.AsNoTrackingWithIdentityResolution();
        }

        if (specification.UseGlobalFilters is false)
        {
            queryable = queryable.IgnoreQueryFilters();
        }

        return queryable;
    }

    internal static IQueryable<TResponse> UseSpecification<TEntity, TResponse>(this IQueryable<TEntity> queryable, SpecificationWithMapping<TEntity, TResponse> specification)
        where TEntity : class, IEntityBase
    {
        ArgumentNullException
            .ThrowIfNull(specification.Mapping, $"{nameof(SpecificationWithMapping<TEntity, TResponse>)} must contain Select statement");

        var queryableWithMapping = queryable
            .UseSpecification((Specification<TEntity>)specification)
            .Select(specification.Mapping);

        if (specification.UseDistinct)
        {
            queryableWithMapping = queryableWithMapping.Distinct();
        }

        return queryableWithMapping;
    }
}
