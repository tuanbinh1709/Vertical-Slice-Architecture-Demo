namespace Refactor.PaymentGate.Api.Datas;

public class RefactorPaymentGateDbContext(DbContextOptions options)
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
