namespace Refactor.PaymentGate.Api.PaymentOrganizations.Sorting;

public static partial class Constants
{
    public static partial class Sorting
    {
        public static class PaymentOrganization
        {
            public readonly static IReadOnlyCollection<string> AllowedPaymentOrganizationSortProperties = AsReadOnlyCollection
            (
                 nameof(PaymentOrganizations.PaymentOrganization.Name),
            nameof(PaymentOrganizations.PaymentOrganization.SchoolCode),
                 nameof(PaymentOrganizations.PaymentOrganization.SchoolLevelCode)
            );

            public readonly static IReadOnlyCollection<string> CommonAllowedPaymentOrganizationSortProperties = AsReadOnlyCollection
            (
                 nameof(PaymentOrganizations.PaymentOrganization.Name),
                 nameof(PaymentOrganizations.PaymentOrganization.SchoolCode),
                 nameof(PaymentOrganizations.PaymentOrganization.SchoolLevelCode)
            );

            public readonly static IList<SortByEntry> CommonPaymentOrganizationSortProperties =
            [
                new SortByEntry() { PropertyName = nameof(PaymentOrganizations.PaymentOrganization.Name), SortDirection = SortDirection.Ascending, SortPriority = 1 },
                new SortByEntry() { PropertyName = nameof(PaymentOrganizations.PaymentOrganization.SchoolCode), SortDirection = SortDirection.Ascending, SortPriority = 2 },
                new SortByEntry() { PropertyName = nameof(PaymentOrganizations.PaymentOrganization.SchoolLevelCode), SortDirection = SortDirection.Ascending, SortPriority = 3 }
            ];
        }
    }
}