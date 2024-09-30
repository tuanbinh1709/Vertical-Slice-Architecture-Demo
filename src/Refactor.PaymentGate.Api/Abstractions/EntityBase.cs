namespace Refactor.PaymentGate.Api.Abstractions;

public class EntityBase : IEntityBase
{
    [Key]
    public virtual string Id { get; set; } = GenerateShortGuid();

    public virtual DateTime CreatedAt { get; set; }

    public virtual DateTime? UpdatedAt { get; set; }
}

public interface IEntityBase
{
    string Id { get; set; }

    DateTime CreatedAt { get; set; }

    DateTime? UpdatedAt { get; set; }
}
