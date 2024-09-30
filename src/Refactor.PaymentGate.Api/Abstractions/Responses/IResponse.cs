namespace Refactor.PaymentGate.Api.Abstractions.Responses;

public interface IResponse
{

}

public interface ICreatedResponse : IResponse
{
    string Id { get; }
}
