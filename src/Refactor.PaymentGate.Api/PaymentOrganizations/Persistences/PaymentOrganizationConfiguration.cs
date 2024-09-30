namespace Refactor.PaymentGate.Api.PaymentOrganizations.Persistences;

public class PaymentOrganizationConfiguration : IEntityTypeConfiguration<PaymentOrganization>
{
    public void Configure(EntityTypeBuilder<PaymentOrganization> builder)
    {
        builder.ConfigureAuditableEntity();

        builder
            .Property(e => e.Id)
            .HasMaxLength(26)
            .IsRequired();

        builder
            .Property(e => e.Name)
            .HasConversion<NameConverter, NameComparer>()
            .HasColumnName(nameof(Name))
            .HasMaxLength(Name.MaxLength)
            .IsRequired();

        builder
            .Property(e => e.SchoolCode)
            .HasConversion<SchoolCodeConverter, SchoolCodeComparer>()
            .HasColumnName(nameof(SchoolCode))
            .HasMaxLength(SchoolLevelCode.MaxLength)
            .IsRequired();

        builder.Property(e => e.SchoolLevelCode)
            .HasConversion<SchoolLevelCodeConverter, SchoolLevelCodeComparer>()
            .HasColumnName(nameof(SchoolLevelCode))
            .HasMaxLength(SchoolLevelCode.MaxLength)
            .IsRequired();
    }
}
