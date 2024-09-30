﻿namespace Refactor.PaymentGate.Api.PaymentOrganizations.Errors;

public static partial class DomainError
{
    public static class NameError
    {
        public static readonly Error Empty = Error.New(
            $"{nameof(SchoolCodeError)}.{nameof(Empty)}",
            $"{nameof(SchoolCodeError)} is empty.");

        public static readonly Error TooLong = Error.New(
            $"{nameof(SchoolCodeError)}.{nameof(TooLong)}",
            $"{nameof(SchoolCodeError)} name must be at most {SchoolLevelCode.MaxLength} characters.");
    }
}
