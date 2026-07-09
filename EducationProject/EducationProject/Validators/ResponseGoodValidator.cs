using EducationProject.API.DTO;
using FluentValidation;

namespace EducationProject.API.Validators
{
    public class ResponseGoodValidator : AbstractValidator<ResponseGoodDTO>
    {
        public ResponseGoodValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("ID должен быть больше 0");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название товара обязательно")
                .MaximumLength(200).WithMessage("Название не может быть длиннее 200 символов");
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Цена не может быть отрицательной");
        }
    }
}
