namespace Refactor.PaymentGate.Api.PaymentOrganizations.ValueObjects;

public sealed class SchoolLevelCode : ValueObject
{
    public const int MaxLength = 16;

    private SchoolLevelCode(string value)
    {
        Value = value;
    }

    public new string Value { get; }

    public static ValidationResult<SchoolLevelCode> Create(string schoolLevelCode)
    {
        var errors = Validate(schoolLevelCode);
        return errors.CreateValidationResult(() => new SchoolLevelCode(schoolLevelCode));
    }

    public static IList<Error> Validate(string username)
    {
        return EmptyList<Error>()
            .If(string.IsNullOrWhiteSpace(username), SchoolLevelCodeError.Empty)
            .If(username.Length > MaxLength, SchoolLevelCodeError.TooLong)
            .If(username.ContainsIllegalCharacter(), SchoolLevelCodeError.ContainsIllegalCharacter);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
