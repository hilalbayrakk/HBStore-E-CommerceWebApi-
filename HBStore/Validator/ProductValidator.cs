using FluentValidation;
using HBStore.Model;

namespace HBStore.Validator
{
    public class ProductValidator : AbstractValidator<Product>
    {

        public ProductValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Product ismi boş olamaz.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Product ismi 2 harften az olamaz.");
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır.");
            RuleFor(x => x.UnitsInStock).GreaterThanOrEqualTo(0);

        }
    }
}