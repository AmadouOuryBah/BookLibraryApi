using FluentValidation;
using Library.BusinessLayer.Requests;
using Microsoft.IdentityModel.Tokens;

namespace Library.Presentation.Validators
{
    public class GenreValidator : AbstractValidator<GenreRequest>
    {
        public GenreValidator()
        {
            RuleFor(genre => genre.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .WithMessage("genre name must contain value and length more than 3");

            RuleFor(genre => genre.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .WithMessage("descritpion must contain value and length more than 3");
        }
    }
}
