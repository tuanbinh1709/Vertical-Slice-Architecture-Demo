namespace Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.OffsetPageDynamic;

public class PaymentOrganizationOffsetPageDynamicHandler(IPaymentOrganizationData paymentOrganizationData)
    : IOffsetPageQueryHandler<PaymentOrganizationOffsetPageDynamicQuery, PaymentOrganizationOffsetPageDynamicResponse,
        PaymentOrganizationDynamicFilter, PaymentOrganizationDynamicSortBy, OffsetPage>
{
    public async Task<IResult<OffsetPageResponse<PaymentOrganizationOffsetPageDynamicResponse>>> Handle(PaymentOrganizationOffsetPageDynamicQuery request, CancellationToken cancellationToken)
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
    public static Expression<Func<PaymentOrganization, PaymentOrganizationOffsetPageDynamicResponse>> PaymentOrganizationResponse =>
        po => new PaymentOrganizationOffsetPageDynamicResponse
        (
            po.Id,
            po.Name.Value,
            po.SchoolCode.Value,
            po.SchoolLevelCode.Value
        );
}