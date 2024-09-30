namespace Refactor.PaymentGate.Api.PaymentOrganizations.UseCases.Update;

public class UpdatePaymentOrganizationHandler(
    IPaymentOrganizationData paymentOrganizationData,
    IValidator validator
    )
    : ICommandHandler<UpdatePaymentOrganizationCommand, UpdatePaymentOrganizationResponse>
{
    public async Task<IResult<UpdatePaymentOrganizationResponse>> Handle(UpdatePaymentOrganizationCommand request, CancellationToken cancellationToken)
    {
        var paymentOrganization = await paymentOrganizationData.FindAsync(request.Id);

        ValidationResult<Name> nameResult = Name.Create(request.Name);
        ValidationResult<SchoolCode> schoolCodeResult = SchoolCode.Create(request.SchoolCode);
        ValidationResult<SchoolLevelCode> schoolLevelCodeResult = SchoolLevelCode.Create(request.SchoolLevelCode);

        bool isExists = await paymentOrganizationData
            .IsExists(schoolCodeResult.Value, schoolLevelCodeResult.Value);

        validator
            .Validate(nameResult)
            .Validate(schoolCodeResult)
            .Validate(schoolLevelCodeResult)
            .If(isExists, Error.AlreadyExists<PaymentOrganization>($"{request.SchoolCode}-{request.SchoolLevelCode}"))
            .If(paymentOrganization is null, Error.NotFound<PaymentOrganization>($"{request.Id}"));

        if (validator.IsInvalid)
        {
            return validator.Failure<UpdatePaymentOrganizationResponse>();
        }

        paymentOrganization!.Update(nameResult.Value, schoolCodeResult.Value, schoolLevelCodeResult.Value);

        paymentOrganizationData.Create(paymentOrganization);

        return Result
            .Success(new UpdatePaymentOrganizationResponse(paymentOrganization.Id,
                paymentOrganization.Name.Value,
                paymentOrganization.SchoolCode.Value,
                paymentOrganization.SchoolLevelCode.Value));
    }
}

