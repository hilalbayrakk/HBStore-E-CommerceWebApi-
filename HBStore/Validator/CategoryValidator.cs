using FluentValidation;
using HBStore.Model;

namespace HBStore.Validator
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Kategori adı boş bırakılamaz!");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Kategori adı 50 karakterden uzun olamaz.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Kategori adı 2 karakterden kısa olamaz.");
        }
    }
}