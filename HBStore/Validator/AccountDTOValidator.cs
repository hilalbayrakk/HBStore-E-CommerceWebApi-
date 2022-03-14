using FluentValidation;
using HBStore.DTO;

namespace HBStore.Validator
{
    public class AccountDTOValidator : AbstractValidator<AccountDTO>
    {
        public AccountDTOValidator()
        {
            RuleFor(x => x.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage("Email formati hatalıdır");
            RuleFor(x => x.Password).NotNull().WithMessage("Password kurallara düzgün bir şekilde oluşturulmalıdır.");

        }
    }
}