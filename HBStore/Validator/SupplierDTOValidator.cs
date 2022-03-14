using FluentValidation;
using HBStore.DTO;

namespace HBStore.Validator
{
    public class SupplierDTOValidator : AbstractValidator<SupplierDTO>
    {
        public SupplierDTOValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Supplier Name Alanı Boş Geçilemez !!!")
                            .Matches(@"^[a-zA-Z ]+$").WithMessage("Supplier Name İçerisinde Harf ve Boşluk Karakterine İzin Verilir !!!")
                            .Length(5, 50).WithMessage("Supplier Name 5 ile 50 Karakter Uzunlukta Olmalıdır !!!");

            RuleFor(x => x.Rating).Must(RatingControl).WithMessage("Rating 0-10 Aralığında Girilmesi Gerekmektedir !!!");
        }

        private bool RatingControl(double Rating)
        {
            if (Rating >= 0 && Rating <= 10) return true;
            return false;
        }

    }
}