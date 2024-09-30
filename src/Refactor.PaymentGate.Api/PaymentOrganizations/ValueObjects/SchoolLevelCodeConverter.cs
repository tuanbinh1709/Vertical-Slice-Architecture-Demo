namespace Refactor.PaymentGate.Api.PaymentOrganizations.ValueObjects;

public sealed class SchoolLevelCodeConverter : ValueConverter<SchoolLevelCode, string>
{
    public SchoolLevelCodeConverter()
        : base(schoolLevelCode => schoolLevelCode.Value,
            @string => SchoolLevelCode.Create(@string).Value)
    { }
}

public sealed class SchoolLevelCodeComparer : ValueComparer<SchoolLevelCode>
{
    public SchoolLevelCodeComparer()
        : base((schoolLevelCode1, schoolLevelCode2) => schoolLevelCode1!.Value == schoolLevelCode2!.Value,
            schoolLevelCode => schoolLevelCode.GetHashCode())
    { }
}
