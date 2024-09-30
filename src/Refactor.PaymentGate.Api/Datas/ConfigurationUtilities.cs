namespace Refactor.PaymentGate.Api.Datas;

public static class ConfigurationUtilities
{
    /// <summary>
    /// Configure an entity to be auditable. The "UpdatedOn" column will be used for concurrency by default.
    /// So when the two simultaneous requests would aim to change the auditable entity, the first one would succeed, while the second one would fail, because the "UpdatedOn" properties would differ.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="builder"></param>
    /// <param name="useUpdatedOnAsConcurrencyToken">If true, the UpdatedOn column will be used as a ConcurrencyToken and its precision will be increased up to nanoseconds</param>
    /// <returns></returns>
    public static EntityTypeBuilder<TEntity> ConfigureAuditableEntity<TEntity>(this EntityTypeBuilder<TEntity> builder, bool useUpdatedOnAsConcurrencyToken = true)
        where TEntity : EntityBase
    {
        builder.Property(o => o.CreatedAt)
            .HasColumnType(ColumnType.DateTime2(2));

        if (useUpdatedOnAsConcurrencyToken)
        {
            builder.Property(o => o.UpdatedAt)
                .HasColumnType(ColumnType.DateTime2(7))
                .IsConcurrencyToken(true)
                .IsRequired(false);

            return builder;
        }

        builder.Property(o => o.UpdatedAt)
            .HasColumnType(ColumnType.DateTime2(2))
            .IsRequired(false);

        return builder;
    }
}
