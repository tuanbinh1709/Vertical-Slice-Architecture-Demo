namespace Refactor.PaymentGate.Api.Options;

public sealed class DatabaseOptionsValidator : IValidateOptions<DatabaseOptions>
{
    public ValidateOptionsResult Validate(string? name, DatabaseOptions options)
    {
        var validationResult = string.Empty;

        if (string.IsNullOrWhiteSpace(options.ConnectionString))
        {
            validationResult += "Connection string is missing. ";
        }

        if (options.MaxRetryCount < 1)
        {
            validationResult += "Retry Count is less than one. ";
        }

        if (options.MaxRetryDelay < 1)
        {
            validationResult += "Retry delay is less than one. ";
        }

        if (options.CommandTimeout < 1)
        {
            validationResult += "Command timeout is less than one. ";
        }

        if (!string.IsNullOrWhiteSpace(validationResult))
        {
            return ValidateOptionsResult.Fail(validationResult);
        }

        return ValidateOptionsResult.Success;
    }
}
