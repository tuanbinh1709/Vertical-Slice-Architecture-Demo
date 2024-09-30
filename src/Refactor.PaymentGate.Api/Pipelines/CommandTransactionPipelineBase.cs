using Refactor.PaymentGate.Api.Abstractions.UnitOfWorks;

namespace Refactor.PaymentGate.Api.Pipelines;

public class CommandTransactionPipelineBase<TCommandResponse>(IUnitOfWork<RefactorPaymentGateDbContext> unitOfWork)
where TCommandResponse : IResult
{
    protected readonly IUnitOfWork UnitOfWork = unitOfWork;

    protected async Task<TCommandResponse> BeginTransactionAsync(RequestHandlerDelegate<TCommandResponse> next, CancellationToken cancellationToken)
    {
        using var transaction = await UnitOfWork.BeginTransactionAsync(cancellationToken);

        var result = await next();

        if (result.IsSuccess)
        {
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        else
        {
            await transaction.RollbackAsync(cancellationToken);
        }

        return result;
    }
}
