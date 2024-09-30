namespace Refactor.PaymentGate.Api.Abstractions.Results;

public interface IValidationResult
{
    Error[] ValidationErrors { get; }
}