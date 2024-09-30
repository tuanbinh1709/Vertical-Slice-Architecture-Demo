using Refactor.PaymentGate.Api.Abstractions.DDD.Specifications.Common;
using System.Linq.Expressions;

namespace Refactor.PaymentGate.Api.PaymentOrganizations.Persistences;

public class PaymentOrganizationData(RefactorPaymentGateDbContext context)
    : IPaymentOrganizationData
{
    public void Create(PaymentOrganization entity)
        => context.Set<PaymentOrganization>().Add(entity);

    public void Delete(PaymentOrganization entity)
        => context.Set<PaymentOrganization>().Remove(entity);

    public async Task<PaymentOrganization?> FindAsync(string id)
        => await context.Set<PaymentOrganization>().FirstOrDefaultAsync(e => e.Id == id);

    public async Task<bool> IsExists(SchoolCode schoolCode, SchoolLevelCode schoolLevelCode)
        => await context
            .Set<PaymentOrganization>()
            .AnyAsync(e => e.SchoolCode == schoolCode
                && e.SchoolLevelCode == schoolLevelCode);

    public async Task<(IList<TResponse> Responses, int TotalCount)> PageAsync<TResponse>(
        IOffsetPage page, CancellationToken cancellationToken, IFilter<PaymentOrganization>? filter = null,
        ISortBy<PaymentOrganization>? sort = null, Expression<Func<PaymentOrganization, TResponse>>? mapping = null,
        params Expression<Func<PaymentOrganization, object>>[] includes)
    {
        var specification = CommonSpecification.WithMapping.Create(
            filter,
            null,
            sort,
            mapping: mapping,
            includes: includes
        );

        return await context
            .Set<PaymentOrganization>()
            .UseSpecification(specification)
            .PageAsync(page, cancellationToken);
    }

    public void Update(PaymentOrganization entity)
        => context.Set<PaymentOrganization>().Update(entity);
}
