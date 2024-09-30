namespace Refactor.PaymentGate.Api.Abstractions.Exceptions;

public sealed class BadRequestException(string message) : Exception(message);
