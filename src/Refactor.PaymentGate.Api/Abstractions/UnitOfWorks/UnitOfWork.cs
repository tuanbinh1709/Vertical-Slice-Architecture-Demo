namespace Refactor.PaymentGate.Api.Abstractions.UnitOfWorks;

//UnitOfWork class to handler transactions
//Benefits:
//1. We do not want to pollute the application layer with entity framework
//2. We do not expose any implementation details when we inject IUnitOfWork interface
//a) since we use the repository pattern with UnitOfWork, the repositories do not contain SaveChanges method.
//This force us to call SaveChanges at the end of our business transactions from the UnitOfWork.
//So this removes the responsibility of SavingChanges from the repositories and moves it to the UnitOfWork
//b) since we use IUnitOfWork interface we can provide a mock for this interface
//3. Move the logic from the interceptors to the UnitOfWork
public sealed class UnitOfWork<TContext>
(
    TContext dbContext
)
    : IUnitOfWork<TContext>
        where TContext : DbContext
{
    private const string _defaultUsername = "Unknown";
    private readonly TContext _dbContext = dbContext;

    public TContext Context => _dbContext;

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return Context
            .Database
            .BeginTransactionAsync(cancellationToken);
    }

    public IExecutionStrategy CreateExecutionStrategy()
    {
        return Context
            .Database
            .CreateExecutionStrategy();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        UpdateAuditableEntities();

        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditableEntities()
    {
        IEnumerable<EntityEntry<EntityBase>> entries =
            _dbContext
                .ChangeTracker
                .Entries<EntityBase>()
                .Where(entry => entry.State is Added or Modified);

        foreach (EntityEntry<EntityBase> entityEntry in entries)
        {
            if (entityEntry.State is Added)
            {
                entityEntry.Property(a => a.CreatedAt).CurrentValue = DateTime.UtcNow;
                entityEntry.Property(a => a.UpdatedAt).CurrentValue = null;
            }

            if (entityEntry.State is Modified)
            {
                entityEntry.Property(a => a.UpdatedAt).CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
