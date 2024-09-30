using Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.Get;
using Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.Update;

namespace Refactor.PaymentGate.Api.PaymentOrganizations;

public static class PaymentOrganizationApis
{
    public static RouteGroupBuilder MapPaymentOrganizationsApiV1(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/payment-organizations").HasApiVersion(1.0);

        api.MapGet("{id}", Get);
        api.MapPost("/", Create);
        api.MapPut("/{id}", Update);

        return api;
    }

    public static async Task<IHttpResult> Get(string id, [AsParameters] PaymentOrganizationService service)
        => await Result.Create(new GetPaymentOrganizationQuery(id))
        .CallHandler(query => service.Mediator.Send(query))
        .HandleGet();

    public static async Task<IHttpResult> Create(CreatePaymentOrganizationCommand command, [AsParameters] PaymentOrganizationService service)
        => await Result.Create(command)
        .CallHandler(command => service.Mediator.Send(command))
        .HandleCreated("api/payment-organizations");

    public static async Task<IHttpResult> Update(string id, UpdatePaymentOrganizationRequest request, [AsParameters] PaymentOrganizationService service)
       => await Result.Create(new UpdatePaymentOrganizationCommand(id, request.Name, request.SchoolCode, request.SchoolLevelCode))
        .CallHandler(command => service.Mediator.Send(command))
        .HandleNotCreated();
}
