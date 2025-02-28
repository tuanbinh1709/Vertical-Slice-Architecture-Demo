using static Refactor.PaymentGate.Api.PaymentOrganizations.Filtering.Constants.Filtering.PaymentOrganization;

namespace Refactor.PaymentGate.Api.PaymentOrganizations.Filtering;

public sealed record PaymentOrganizationDynamicFilter : IDynamicFilter<PaymentOrganization>
{
    public static IReadOnlyCollection<string> AllowedFilterProperties { get; } = AllowedPaymentOrganizationFilterProperties;
    public static IReadOnlyCollection<string> AllowedFilterOperations { get; } = AllowedPaymentOrganizationFilterOperations;

    public required IList<FilterByEntry> FilterProperties { get; init; }

    public IQueryable<PaymentOrganization> Apply(IQueryable<PaymentOrganization> queryable)
    {
        if (FilterProperties.IsNullOrEmpty())
        {
            return queryable;
        }

        return queryable
            .Where(FilterProperties);
    }
}