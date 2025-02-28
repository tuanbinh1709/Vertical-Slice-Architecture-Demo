namespace Refactor.PaymentGate.Api.PaymentOrganizations.Filtering;

public static partial class Constants
{
    public static partial class Filtering
    {
        public static class PaymentOrganization
        {
            public readonly static IReadOnlyCollection<string> AllowedPaymentOrganizationFilterProperties = AsReadOnlyCollection
            (
                 nameof(PaymentOrganizations.PaymentOrganization.Name),
                 nameof(PaymentOrganizations.PaymentOrganization.SchoolCode),
                 nameof(PaymentOrganizations.PaymentOrganization.SchoolLevelCode)
            );

            public readonly static IReadOnlyCollection<string> AllowedPaymentOrganizationFilterOperations = AsList
            (
                 nameof(string.Contains),
                 nameof(string.StartsWith),
                 nameof(string.EndsWith)
            )
                .Concat(GetNamesOf<ExpressionType>())
                .ToList()
                .AsReadOnly();
        }
    }
}