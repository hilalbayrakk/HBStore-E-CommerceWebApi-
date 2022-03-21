namespace HBStore.Validator
{
    public class AccountDTOValidator : AbstractValidator<AccountDTO>
    {
        public AccountDTOValidator()
        {
            RuleFor(x => x.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage("Gecerli bir email adresi giriniz!");
            RuleFor(x => x.Password).NotNull().WithMessage("Sifre kurallara uygun bir şekilde oluşturulmalidir.");

        }
    }
}