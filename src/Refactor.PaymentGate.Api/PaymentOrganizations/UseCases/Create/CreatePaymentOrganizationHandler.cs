namespace Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.Create;

public class CreatePaymentOrganizationHandler(
    IPaymentOrganizationData paymentOrganizationData,
    IValidator validator
    )
    : ICommandHandler<CreatePaymentOrganizationCommand, CreatePaymentOrganizationResponse>
{
    public async Task<IResult<CreatePaymentOrganizationResponse>> Handle(CreatePaymentOrganizationCommand request, CancellationToken cancellationToken)
    {

        ValidationResult<Name> nameResult = Name.Create(request.Name);
        ValidationResult<SchoolCode> schoolCodeResult = SchoolCode.Create(request.SchoolCode);
        ValidationResult<SchoolLevelCode> schoolLevelCodeResult = SchoolLevelCode.Create(request.SchoolLevelCode);

        bool isExists = await paymentOrganizationData
            .IsExists(schoolCodeResult.Value, schoolLevelCodeResult.Value);

        validator
            .Validate(nameResult)
            .Validate(schoolCodeResult)
            .Validate(schoolLevelCodeResult)
            .If(isExists, Error.AlreadyExists<PaymentOrganization>($"{request.SchoolCode}-{request.SchoolLevelCode}"));

        if (validator.IsInvalid)
        {
            return validator.Failure<CreatePaymentOrganizationResponse>();
        }

        var paymentOrganization = PaymentOrganization.Create(nameResult.Value, schoolCodeResult.Value, schoolLevelCodeResult.Value);

        paymentOrganizationData.Create(paymentOrganization);

        return Result
            .Success(new CreatePaymentOrganizationResponse(paymentOrganization.Id,
                paymentOrganization.Name.Value,
                paymentOrganization.SchoolCode.Value,
                paymentOrganization.SchoolLevelCode.Value));
    }
}
