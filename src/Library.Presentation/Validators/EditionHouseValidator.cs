using FluentValidation;
using Library.BusinessLayer.Requests;

namespace Library.Presentation.Validators
{
    public class EditionHouseValidator : AbstractValidator<EditionHouseRequest>
    {
        public EditionHouseValidator()
        {
            RuleFor(eHouse => eHouse.City)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4)
                .WithMessage("genre name must contain value and length more than 4");

            RuleFor(eHouse => eHouse.Address)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .WithMessage("descritpion must contain value and length more than 5");
        }
    }
}
