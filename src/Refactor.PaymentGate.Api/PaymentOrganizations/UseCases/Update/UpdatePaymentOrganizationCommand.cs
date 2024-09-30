namespace Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.Update;

public class UpdatePaymentOrganizationCommand(string id, string name, string schoolCode, string schoolLevelCode)
    : ICommand<UpdatePaymentOrganizationResponse>
{
    public string Id { get; } = id;

    public string Name { get; } = name;

    public string SchoolCode { get; } = schoolCode;

    public string SchoolLevelCode { get; } = schoolLevelCode;
}
