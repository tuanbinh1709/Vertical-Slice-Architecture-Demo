using static Refactor.PaymentGate.Api.PaymentOrganizations.Sorting.Constants.Sorting.PaymentOrganization;

namespace Refactor.PaymentGate.Api.PaymentOrganizations.Sorting;

public sealed record PaymentOrganizationDynamicSortBy : IDynamicSortBy<PaymentOrganization>
{
    public static IReadOnlyCollection<string> AllowedSortProperties { get; } = AllowedPaymentOrganizationSortProperties;

    public required IList<SortByEntry> SortProperties { get; init; }

    public IQueryable<PaymentOrganization> Apply(IQueryable<PaymentOrganization> queryable)
    {
        return queryable.Sort(SortProperties);
    }
}
