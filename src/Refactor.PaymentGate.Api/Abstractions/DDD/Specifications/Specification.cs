using System.Linq.Expressions;

namespace Refactor.PaymentGate.Api.Abstractions.DDD.Specifications;

public sealed class SpecificationWithMapping<TEntity, TResponse> : Specification<TEntity>
    where TEntity : class, IEntityBase
{
    internal Expression<Func<TEntity, TResponse>>? Mapping { get; private set; } = null;
    internal bool UseDistinct { get; private set; }

    internal new static SpecificationWithMapping<TEntity, TResponse> New()
    {
        return new SpecificationWithMapping<TEntity, TResponse>();
    }

    internal SpecificationWithMapping<TEntity, TResponse> AddMapping(Expression<Func<TEntity, TResponse>>? mapping)
    {
        Mapping = mapping;
        return this;
    }

    internal SpecificationWithMapping<TEntity, TResponse> ApplyDistinct()
    {
        UseDistinct = true;
        return this;
    }
}

public class Specification<TEntity> : ISpecification<TEntity>
    where TEntity : class, IEntityBase
{
    //Tag
    public string? QueryTag { get; private set; }

    //Flags
    public bool AsSplitQuery { get; private set; }
    public bool AsNoTracking { get; private set; }
    public bool AsTracking { get; private set; }
    public bool AsNoTrackingWithIdentityResolution { get; private set; }
    public bool UseGlobalFilters { get; private set; } = true;

    //Filters
    public IFilter<TEntity>? Filter { get; private set; } = null;
    public List<Expression<Func<TEntity, bool>>> FilterExpressions { get; } = [];

    //SortBy
    public ISortBy<TEntity>? SortBy { get; private set; } = null;
    public (Expression<Func<TEntity, object>> SortBy, SortDirection SortDirection)? SortByExpression { get; private set; }
    public (Expression<Func<TEntity, object>> SortBy, SortDirection SortDirection)? ThenByExpression { get; private set; }

    //Includes
    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];
    public Func<IQueryable<TEntity>, IQueryable<TEntity>>? IncludeAction { get; private set; } = null;

    #region Methods

    public static Specification<TEntity> New()
    {
        return new Specification<TEntity>();
    }

    public Specification<TEntity> AddTag(string queryTag)
    {
        QueryTag = queryTag;
        return this;
    }

    public Specification<TEntity> IgnoreGlobalFilters()
    {
        UseGlobalFilters = false;
        return this;
    }

    public Specification<TEntity> UseSplitQuery()
    {
        AsSplitQuery = true;
        return this;
    }

    public Specification<TEntity> UseNoTracking()
    {
        AsNoTracking = true;
        return this;
    }

    public Specification<TEntity> UseTracking()
    {
        AsTracking = true;
        return this;
    }

    public Specification<TEntity> UseNoTrackingWithIdentityResolution()
    {
        AsNoTrackingWithIdentityResolution = true;
        return this;
    }

    public Specification<TEntity> AddFilter(IFilter<TEntity>? filter)
    {
        Filter = filter;
        return this;
    }

    public Specification<TEntity> AddFilter(Expression<Func<TEntity, bool>>? filterExpression)
    {
        if (filterExpression is not null)
        {
            FilterExpressions.Add(filterExpression);
        }
        return this;
    }

    public Specification<TEntity> AddFilters(params Expression<Func<TEntity, bool>>[] filterExpressions)
    {
        foreach (var filterExpression in filterExpressions)
        {
            FilterExpressions.Add(filterExpression);
        }

        return this;
    }

    public Specification<TEntity> AddSortBy(ISortBy<TEntity>? sortBy)
    {
        SortBy = sortBy;
        return this;
    }

    public Specification<TEntity> OrderBy(Expression<Func<TEntity, object>> sortByExpression, SortDirection sortDirection)
    {
        SortByExpression = (sortByExpression, sortDirection);
        return this;
    }

    public Specification<TEntity> ThenBy(Expression<Func<TEntity, object>> thenByExpression, SortDirection sortDirection)
    {
        if (SortByExpression is null)
        {
            throw new InvalidOperationException($"{nameof(SortByExpression)} should be specified before {nameof(ThenByExpression)}");
        }

        if (ThenByExpression is not null)
        {
            throw new InvalidOperationException($"{nameof(ThenByExpression)} can be specified once");
        }

        ThenByExpression = (thenByExpression, sortDirection);
        return this;
    }

    public Specification<TEntity> AddIncludes(params Expression<Func<TEntity, object>>[] includeExpressions)
    {
        foreach (var includeExpression in includeExpressions)
        {
            IncludeExpressions.Add(includeExpression);
        }

        return this;
    }

    /// <summary>
    /// Use only when there is a need for ThenInclude for collection and then further include.
    /// </summary>
    /// <remarks>
    /// Example usage: .AddIncludeAction(orderHeader => orderHeader.Include(o => o.OrderLines).ThenInclude(od => od.Product)) 
    /// </remarks>
    /// <param name="includeAction"></param>
    public Specification<TEntity> AddIncludesWithThenIncludesAction(Expression<Func<IQueryable<TEntity>, IQueryable<TEntity>>> includeAction)
    {
        var includeActionBody = includeAction.ToString();

        if (includeActionBody.NotContains("ThenInclude"))
        {
            throw new InvalidOperationException($"Input of {AddIncludesWithThenIncludesAction} must contain 'ThenInclude' call. Use {nameof(AddIncludes)} if 'ThenInclude' is not required.");
        }

        if (ContainsMethodCallDifferentFromIncludeOrThenInclude(includeActionBody))
        {
            throw new InvalidOperationException($"Input can only contain 'Include' or 'ThenInclude' calls.");
        }

        IncludeAction = includeAction.Compile();
        return this;
    }

    private static bool ContainsMethodCallDifferentFromIncludeOrThenInclude(string includeActionBody)
    {
        return includeActionBody
            .RemoveAll("ThenInclude(", "Include(")
            .Contains('(');
    }
    #endregion
}
