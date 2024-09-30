namespace Refactor.PaymentGate.Api.PaymentOrganizations;

public class PaymentOrganization : EntityBase
{
    private PaymentOrganization() { }

    private PaymentOrganization(Name name, SchoolCode schoolCode, SchoolLevelCode schoolLevelCode)
    {
        Id = Ulid.NewUlid().ToString();
        Name = name;
        SchoolCode = schoolCode;
        SchoolLevelCode = schoolLevelCode;
    }

    public Name Name { get; private set; } = default!;

    public SchoolCode SchoolCode { get; private set; } = default!;

    public SchoolLevelCode SchoolLevelCode { get; private set; } = default!;

    public static PaymentOrganization Create(Name name, SchoolCode schoolCode, SchoolLevelCode schoolLevelCode)
        => new(name, schoolCode, schoolLevelCode);

    public void Update(Name name, SchoolCode schoolCode, SchoolLevelCode schoolLevelCode)
    {
        Name = name;
        SchoolCode = schoolCode;
        SchoolLevelCode = schoolLevelCode;
    }
}
