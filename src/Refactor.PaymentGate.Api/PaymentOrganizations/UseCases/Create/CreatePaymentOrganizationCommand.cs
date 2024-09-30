namespace Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.Create;

public class CreatePaymentOrganizationCommand(string name, string schoolCode, string schoolLevelCode)
    : ICommand<CreatePaymentOrganizationResponse>
{
    public string Name { get; set; } = name;

    public string SchoolCode { get; set; } = schoolCode;

    public string SchoolLevelCode { get; set; } = schoolLevelCode;
}
