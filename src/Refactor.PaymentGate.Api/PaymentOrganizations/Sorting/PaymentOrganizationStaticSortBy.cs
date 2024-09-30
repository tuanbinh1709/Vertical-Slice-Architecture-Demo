namespace Refactor.PaymentGate.Api.PaymentOrganizations.Sorting;

public sealed class PaymentOrganizationStaticSortBy : ISortBy<PaymentOrganization>
{
    public SortDirection? Name { get; init; }
    public SortDirection? SchoolCode { get; init; }
    public SortDirection? SchoolLevelCode { get; init; }

    public SortDirection? ThenName { get; init; }
    public SortDirection? ThenSchoolCode { get; init; }
    public SortDirection? ThenSchoolLevelCode { get; init; }

    public IQueryable<PaymentOrganization> Apply(IQueryable<PaymentOrganization> queryable)
    {
        queryable = queryable
            .SortBy(Name, po => po.Name)
            .SortBy(SchoolCode, po => po.SchoolCode)
            .SortBy(SchoolLevelCode, po => po.SchoolLevelCode);

        return ((IOrderedQueryable<PaymentOrganization>)queryable)
            .ThenSortBy(ThenName, po => po.Name)
            .ThenSortBy(ThenSchoolCode, po => po.SchoolCode)
            .ThenSortBy(ThenSchoolLevelCode, po => po.SchoolLevelCode);
    }
}
