namespace Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.Update;

public class UpdatePaymentOrganizationRequest(string name, string schoolCode, string schoolLevelCode)
{
    public string Name { get; } = name;

    public string SchoolCode { get; } = schoolCode;

    public string SchoolLevelCode { get; } = schoolLevelCode;
}