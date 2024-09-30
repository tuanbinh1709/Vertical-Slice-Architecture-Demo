var builder = WebApplication.CreateBuilder(args);

var withApiVersioning = builder.Services.AddApiVersioning();

builder.AddDefaultOpenApi(withApiVersioning);

builder.Services
    .RegisterOptions()
    .RegisterDatabase(builder.Environment)
    .RegisterPipelines()
    .RegisterValidator()
    ;

var app = builder.Build();

//app.MapDefaultEndpoints();

var paymentOrganizations = app.NewVersionedApi("PaymentOrganizations");

paymentOrganizations.MapPaymentOrganizationsApiV1();

app.UseDefaultOpenApi();
app.Run();
