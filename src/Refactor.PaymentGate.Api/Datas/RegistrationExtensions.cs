using Refactor.PaymentGate.Api.Abstractions.UnitOfWorks;

namespace Refactor.PaymentGate.Api.Datas;

public static class RegistrationExtensions
{
    public static IServiceCollection RegisterDatabase(this IServiceCollection services, IHostEnvironment environment)
    {
        services.AddDbContextPool<RefactorPaymentGateDbContext>(optionBuilders =>
        {
            var databaseOptions = services.GetOptions<DatabaseOptions>();

            optionBuilders.UseSqlServer(databaseOptions.ConnectionString, options =>
            {
                options.CommandTimeout(databaseOptions.CommandTimeout);

                options.EnableRetryOnFailure(
                    databaseOptions.MaxRetryCount,
                    TimeSpan.FromSeconds(databaseOptions.MaxRetryDelay),
                    []);
            });

            if (environment.IsDevelopment())
            {
                optionBuilders.EnableDetailedErrors();
                optionBuilders.EnableSensitiveDataLogging(); //DO NOT USE THIS IN PRODUCTION! Used to get parameter values. DO NOT USE THIS IN PRODUCTION!
                optionBuilders.ConfigureWarnings(warningAction =>
                {
                    warningAction.Log(new EventId[]
                    {
                        CoreEventId.FirstWithoutOrderByAndFilterWarning,
                        CoreEventId.RowLimitingOperationWithoutOrderByWarning
                    });
                });
            }
        });

        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

        services.AddScoped<IPaymentOrganizationData, PaymentOrganizationData>();

        return services;
    }
}
