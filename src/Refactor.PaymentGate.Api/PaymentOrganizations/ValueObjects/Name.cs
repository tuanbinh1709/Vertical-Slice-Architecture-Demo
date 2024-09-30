namespace Refactor.PaymentGate.Api.PaymentOrganizations.ValueObjects;

public sealed class Name : ValueObject
{
    public const int MaxLength = 256;

    private Name(string value)
    {
        Value = value;
    }

    public new string Value { get; }

    public static ValidationResult<Name> Create(string schoolLevelCode)
    {
        var errors = Validate(schoolLevelCode);
        return errors.CreateValidationResult(() => new Name(schoolLevelCode));
    }

    public static IList<Error> Validate(string username)
    {
        return EmptyList<Error>()
            .If(string.IsNullOrWhiteSpace(username), NameError.Empty)
            .If(username.Length > MaxLength, NameError.TooLong);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}