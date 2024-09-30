namespace Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.Get;

public class GetPaymentOrganizationResponse(string id, string name, string schoolCode, string schoolLevelCode)
    : IResponse
{
    public string Id { get; } = id;

    public string Name { get; } = name;

    public string SchoolCode { get; } = schoolCode;

    public string SchoolLevelCode { get; } = schoolLevelCode;
}
