namespace Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.Create;

public class CreatePaymentOrganizationRequest(string name, string schoolCode, string schoolLevelCode)
{
    public string Name { get; set; } = name;

    public string SchoolCode { get; set; } = schoolCode;

    public string SchoolLevelCode { get; set; } = schoolLevelCode;
}
