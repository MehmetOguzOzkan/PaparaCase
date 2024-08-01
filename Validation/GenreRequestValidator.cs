using FluentValidation;
using WebApiCase1.DTOs.Requests;

namespace WebApiCase1.Validation
{
    public class GenreRequestValidator : AbstractValidator<GenreRequest>
    {
        public GenreRequestValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Genre name is required.");
        }
    }
}
