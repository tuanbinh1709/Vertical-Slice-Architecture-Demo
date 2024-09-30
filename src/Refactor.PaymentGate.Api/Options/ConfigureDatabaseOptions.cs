namespace Refactor.PaymentGate.Api.Options;

internal sealed class ConfigureDatabaseOptions(
    IConfiguration configuration,
    IWebHostEnvironment environment)
    : IConfigureOptions<DatabaseOptions>
{
    private const string _configurationSectionName = "DatabaseOptions";
    private const string _defaultConnection = "DefaultConnection";
    private const string _testConnection = "TestConnection";

    public void Configure(DatabaseOptions options)
    {
        if (environment.IsProduction())
        {
            options.ConnectionString = configuration
                .GetConnectionString(_defaultConnection);
        }
        else if (environment.IsDevelopment())
        {
            options.ConnectionString = configuration
                .GetConnectionString(_defaultConnection);
        }

        configuration
            .GetSection(_configurationSectionName)
            .Bind(options);
    }
}
