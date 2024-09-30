namespace Refactor.PaymentGate.Api.Abstractions.Validators;

public static class RegistrationExtensions
{
    public static IServiceCollection RegisterValidator(this IServiceCollection services)
    {
        //Validators
        services.AddScoped<IValidator, Validator>();

        return services;
    }
}
