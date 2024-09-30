using System.Linq.Expressions;

namespace Refactor.PaymentGate.Api.Abstractions.DDD.Specifications.Common;

public static partial class CommonSpecification
{
    public static partial class WithMapping
    {
        public static SpecificationWithMapping<TEntity, TResponse> Create<TEntity, TResponse>
        (
            IFilter<TEntity>? filter = null,
            Expression<Func<TEntity, bool>>? customFilter = null,
            ISortBy<TEntity>? sortBy = null,
            Expression<Func<TEntity, TResponse>>? mapping = null,
            params Expression<Func<TEntity, object>>[] includes
        )
            where TEntity : EntityBase
        {
            return SpecificationWithMapping<TEntity, TResponse>.New()
                .AddMapping(mapping)
                .AddIncludes(includes)
                .AddFilter(filter)
                .AddFilter(customFilter)
                .AddSortBy(sortBy)
                .AddTag($"Common {typeof(TEntity).Name} query")
                .AsMappingSpecification<TEntity, TResponse>();
        }
    }
}
