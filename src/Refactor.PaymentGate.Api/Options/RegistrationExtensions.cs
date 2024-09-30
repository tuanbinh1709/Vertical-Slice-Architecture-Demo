namespace Refactor.PaymentGate.Api.Options;

public static class RegistrationExtensions
{
    internal static IServiceCollection RegisterOptions(this IServiceCollection services)
    {
        services.ConfigureOptions<ConfigureDatabaseOptions>();
        services.AddSingleton<IValidateOptions<DatabaseOptions>, DatabaseOptionsValidator>();

        return services;
    }
}
