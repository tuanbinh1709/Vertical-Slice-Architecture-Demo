
namespace Refactor.PaymentGate.Api.PaymentOrganizations.ValueObjects;

public sealed class SchoolCode : ValueObject
{
    public const int MaxLength = 16;

    private SchoolCode(string value)
    {
        Value = value;
    }

    public new string Value { get; }

    public static ValidationResult<SchoolCode> Create(string schoolLevelCode)
    {
        var errors = Validate(schoolLevelCode);
        return errors.CreateValidationResult(() => new SchoolCode(schoolLevelCode));
    }

    public static IList<Error> Validate(string username)
    {
        return EmptyList<Error>()
            .If(string.IsNullOrWhiteSpace(username), SchoolCodeError.Empty)
            .If(username.Length > MaxLength, SchoolCodeError.TooLong)
            .If(username.ContainsIllegalCharacter(), SchoolCodeError.ContainsIllegalCharacter);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
