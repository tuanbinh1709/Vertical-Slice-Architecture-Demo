namespace Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.Get;

public class GetPaymentOrganizationHandler(
    IPaymentOrganizationData paymentOrganizationData,
    IValidator validator
    )
    : IQueryHandler<GetPaymentOrganizationQuery, GetPaymentOrganizationResponse>
{
    public async Task<IResult<GetPaymentOrganizationResponse>> Handle(GetPaymentOrganizationQuery request, CancellationToken cancellationToken)
    {
        var paymentOrganization = await paymentOrganizationData.FindAsync(request.Id);

        validator.If(paymentOrganization is null, Error.NotFound<PaymentOrganization>($"{request.Id}"));

        if (validator.IsInvalid)
        {
            return validator.Failure<GetPaymentOrganizationResponse>();
        }

        return Result
            .Success(new GetPaymentOrganizationResponse(paymentOrganization!.Id,
                paymentOrganization.Name.Value,
                paymentOrganization.SchoolCode.Value,
                paymentOrganization.SchoolLevelCode.Value));
    }
}
