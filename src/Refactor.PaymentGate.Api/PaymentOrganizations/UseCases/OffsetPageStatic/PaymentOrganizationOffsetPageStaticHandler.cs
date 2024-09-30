using Refactor.PaymentGate.Api.PaymentOrganizations.Filtering;
using Refactor.PaymentGate.Api.PaymentOrganizations.Sorting;
using System.Linq.Expressions;

namespace Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.OffsetPageStatic;

public class PaymentOrganizationOffsetPageStaticHandler(IPaymentOrganizationData paymentOrganizationData)
    : IOffsetPageQueryHandler<PaymentOrganizationOffsetPageStaticQuery, PaymentOrganizationOffsetPageStaticResponse,
        PaymentOrganizationStaticFilter, PaymentOrganizationStaticSortBy, OffsetPage>
{
    public async Task<IResult<OffsetPageResponse<PaymentOrganizationOffsetPageStaticResponse>>> Handle(PaymentOrganizationOffsetPageStaticQuery request, CancellationToken cancellationToken)
    {
        var page = await paymentOrganizationData
            .PageAsync(request.Page, cancellationToken, filter: request.Filter, sort: request.SortBy, mapping: PaymentOrganizationMapping.PaymentOrganizationResponse);

        return page
            .ToPageResponse(request.Page)
            .ToResult();
    }
}

public static class PaymentOrganizationMapping
{
    public static Expression<Func<PaymentOrganization, PaymentOrganizationOffsetPageStaticResponse>> PaymentOrganizationResponse =>
        po => new PaymentOrganizationOffsetPageStaticResponse
        (
            po.Id,
            po.Name.Value,
            po.SchoolCode.Value,
            po.SchoolLevelCode.Value
        );
}