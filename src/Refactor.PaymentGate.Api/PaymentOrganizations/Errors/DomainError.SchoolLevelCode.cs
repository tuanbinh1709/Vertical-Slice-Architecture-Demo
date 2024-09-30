namespace Refactor.PaymentGate.Api.PaymentOrganizations.Errors;

public static partial class DomainError
{
    public static class SchoolLevelCodeError
    {
        public static readonly Error Empty = Error.New(
            $"{nameof(SchoolLevelCode)}.{nameof(Empty)}",
            $"{nameof(SchoolLevelCode)} is empty.");

        public static readonly Error TooLong = Error.New(
            $"{nameof(SchoolLevelCode)}.{nameof(TooLong)}",
            $"{nameof(SchoolLevelCode)} name must be at most {SchoolLevelCode.MaxLength} characters.");

        public static readonly Error ContainsIllegalCharacter = Error.New(
            $"{nameof(SchoolLevelCode)}.{nameof(ContainsIllegalCharacter)}",
            $"{nameof(SchoolLevelCode)} contains illegal character.");
    }
}
