namespace Refactor.PaymentGate.Api.Pipelines;

public static class RegistrationExtensions
{
    internal static IServiceCollection RegisterPipelines(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
            configuration.AddOpenBehavior(typeof(CommandTransactionPipeline<,>));
            configuration.AddOpenBehavior(typeof(CommandWithResponseTransactionPipeline<,>));
            configuration.AddOpenBehavior(typeof(LoggingPipeline<,>));
        });

        return services;
    }
}
