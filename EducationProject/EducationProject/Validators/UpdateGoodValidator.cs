using EducationProject.API.DTO;
using FluentValidation;

namespace EducationProject.API.Validators
{
    public class UpdateGoodValidator : AbstractValidator<UpdateGoodDTO>
    {
        public UpdateGoodValidator()
        {
            // прописать для id


            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название товара обязательно")
                .MaximumLength(200).WithMessage("Название не может быть длиннее 200 символов");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Цена не может быть отрицательной");

            RuleFor(x => x.Count)
                .GreaterThanOrEqualTo(0).WithMessage("Количество не может быть отрицательным");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Описание не может быть длиннее 1000 символов");
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Цена не может быть отрицательной");
        }
    }
}
