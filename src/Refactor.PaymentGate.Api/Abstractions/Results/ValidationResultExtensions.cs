namespace Refactor.PaymentGate.Api.Abstractions.Results;

public static class ValidationResultExtensions
{
    public static IDictionary<string, object?> ToDictionary(this IValidationResult validationResult)
    {
        return new Dictionary<string, object?>
        {
            { ProblemDetails.Errors, validationResult.ValidationErrors }
        };
    }
}

