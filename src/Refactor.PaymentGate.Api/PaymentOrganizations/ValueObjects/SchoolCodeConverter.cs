namespace Refactor.PaymentGate.Api.PaymentOrganizations.ValueObjects;

public sealed class SchoolCodeConverter : ValueConverter<SchoolCode, string>
{
    public SchoolCodeConverter() : base(schoolCode => schoolCode.Value, @string => SchoolCode.Create(@string).Value) { }
}

public sealed class SchoolCodeComparer : ValueComparer<SchoolCode>
{
    public SchoolCodeComparer() : base((schoolCode1, schoolCode2) => schoolCode1!.Value == schoolCode2!.Value, schoolCode => schoolCode.GetHashCode()) { }
}
