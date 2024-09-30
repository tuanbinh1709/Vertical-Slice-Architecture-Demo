namespace Refactor.PaymentGate.Api.PaymentOrganizations;

public class PaymentOrganizationService(
    IMediator mediator,
    ILogger<PaymentOrganizationService> logger)
{
    public IMediator Mediator { get; } = mediator;
    public ILogger<PaymentOrganizationService> Logger { get; } = logger;
}
