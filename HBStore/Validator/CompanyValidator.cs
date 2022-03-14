using FluentValidation;
using HBStore.Model;

namespace HBStore.Validator
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).MinimumLength(2);

        }


    }
}