using System.Linq.Expressions;

namespace Refactor.PaymentGate.Api.PaymentOrganizations.Persistences;

public interface IPaymentOrganizationData : IDataBase<PaymentOrganization>
{
    Task<bool> IsExists(SchoolCode schoolCode, SchoolLevelCode schoolLevelCode);

    Task<(IList<TResponse> Responses, int TotalCount)> PageAsync<TResponse>
    (
        IOffsetPage page,
        CancellationToken cancellationToken,
        IFilter<PaymentOrganization>? filter = null,
        ISortBy<PaymentOrganization>? sort = null,
        Expression<Func<PaymentOrganization, TResponse>>? mapping = null,
        params Expression<Func<PaymentOrganization, object>>[] includes
    );
}
