namespace Refactor.PaymentGate.Api.PaymentOrganizations.ValueObjects;

public sealed class NameConverter : ValueConverter<Name, string>
{
    public NameConverter() : base(name => name.Value, @string => Name.Create(@string).Value) { }
}

public sealed class NameComparer : ValueComparer<Name>
{
    public NameComparer() : base((name1, name2) => name1!.Value == name2!.Value, name => name.GetHashCode()) { }
}