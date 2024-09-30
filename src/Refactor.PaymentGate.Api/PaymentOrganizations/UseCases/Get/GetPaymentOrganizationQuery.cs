namespace Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.Get;

public class GetPaymentOrganizationQuery(string id)
    : IQuery<GetPaymentOrganizationResponse>
{
    public string Id { get; } = id;
}
