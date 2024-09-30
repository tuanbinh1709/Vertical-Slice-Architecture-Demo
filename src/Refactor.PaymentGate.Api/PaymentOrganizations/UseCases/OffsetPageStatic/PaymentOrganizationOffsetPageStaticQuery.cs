using Refactor.PaymentGate.Api.PaymentOrganizations.Filtering;
using Refactor.PaymentGate.Api.PaymentOrganizations.Sorting;

namespace Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.OffsetPageStatic;

public sealed class PaymentOrganizationOffsetPageStaticQuery(OffsetPage page)
    : IOffsetPageQuery<PaymentOrganizationOffsetPageStaticResponse, PaymentOrganizationStaticFilter, PaymentOrganizationStaticSortBy, OffsetPage>
{
    public PaymentOrganizationStaticFilter? Filter { get; init; }

    public PaymentOrganizationStaticSortBy? SortBy { get; init; }

    public OffsetPage Page { get; } = page;

}
