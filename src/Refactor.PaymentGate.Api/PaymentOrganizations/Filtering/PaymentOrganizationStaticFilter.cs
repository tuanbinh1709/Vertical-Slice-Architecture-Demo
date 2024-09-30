namespace Refactor.PaymentGate.Api.PaymentOrganizations.Filtering;

public sealed class PaymentOrganizationStaticFilter : IFilter<PaymentOrganization>
{
    public string? Name { get; set; }
    public string? SchoolCode { get; set; }
    public string? SchoolLevelCode { get; set; }

    private bool ByName => Name.IsNullOrWhiteSpace();
    private bool BySchoolCode => SchoolCode.IsNullOrWhiteSpace();
    private bool BySchoolLevelCode => SchoolLevelCode.IsNullOrWhiteSpace();

    public IQueryable<PaymentOrganization> Apply(IQueryable<PaymentOrganization> queryable)
    {
        return queryable
            .Filter(ByName, po => ((string)(object)po.Name).Contains(Name!))
            .Filter(BySchoolCode, po => ((string)(object)po.SchoolCode).Contains(SchoolCode!))
            .Filter(BySchoolLevelCode, po => ((string)(object)po.SchoolLevelCode).Contains(SchoolLevelCode!));
    }
}
