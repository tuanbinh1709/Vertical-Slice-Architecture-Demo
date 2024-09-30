namespace Refactor.PaymentGate.Api.Abstractions.UnitOfWorks;

public interface IUnitOfWork
{
    /// <summary>
    /// Saves all of the pending changes in the unit of work.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The number of entities that have been saved.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Begins a transaction on the current unit of work.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The new database context transaction.</returns>
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

    IExecutionStrategy CreateExecutionStrategy();
}

public interface IUnitOfWork<out TContext> : IUnitOfWork
    where TContext : DbContext
{
    TContext Context { get; }
}