namespace Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.Create;

public class CreatePaymentOrganizationResponse(string id, string name, string schoolCode, string schoolLevelCode)
    : ICreatedResponse
{
    public string Id { get; } = id;
    public string Name { get; } = name;

    public string SchoolCode { get; } = schoolCode;

    public string SchoolLevelCode { get; } = schoolLevelCode;
}
