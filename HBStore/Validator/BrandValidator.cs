using FluentValidation;
using HBStore.Model;

namespace HBStore.Validator
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Markanın ismi boş bırakılamaz. Lütfen bir marka ismi giriniz.");
            RuleFor(x => x.Name).MinimumLength(2);
            RuleFor(x => x.Name).MaximumLength(50);
        }

    }
}