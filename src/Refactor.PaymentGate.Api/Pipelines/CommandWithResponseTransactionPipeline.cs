using Refactor.PaymentGate.Api.Abstractions.UnitOfWorks;

namespace Refactor.PaymentGate.Api.Pipelines;

public sealed class CommandWithResponseTransactionPipeline<TCommandRequest, TCommandResponse>(IUnitOfWork<RefactorPaymentGateDbContext> unitOfWork)
    : CommandTransactionPipelineBase<TCommandResponse>(unitOfWork),
        IPipelineBehavior<TCommandRequest, TCommandResponse>
    where TCommandRequest : class, IRequest<TCommandResponse>
    where TCommandResponse : class, IResult<IResponse>
{
    public async Task<TCommandResponse> Handle(TCommandRequest command, RequestHandlerDelegate<TCommandResponse> next, CancellationToken cancellationToken)
    {
        var executionStrategy = UnitOfWork.CreateExecutionStrategy();
        return await executionStrategy.ExecuteAsync(cancellationToken => BeginTransactionAsync(next, cancellationToken), cancellationToken);
    }
}
