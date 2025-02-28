namespace Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.OffsetPageDynamic;

public sealed class PaymentOrganizationOffsetPageDynamicQuery(OffsetPage page)
    : IOffsetPageQuery<PaymentOrganizationOffsetPageDynamicResponse, PaymentOrganizationDynamicFilter, PaymentOrganizationDynamicSortBy, OffsetPage>
{
    public OffsetPage Page { get; } = page;

    public PaymentOrganizationDynamicFilter? Filter { get; init; }

    public PaymentOrganizationDynamicSortBy? SortBy { get; init; }
}
