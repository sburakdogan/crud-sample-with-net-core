using CityGuide.Domain.Models;
using FluentValidation;

namespace CityGuide.API.Validators
{
    public class LoginRequestModelValidator : AbstractValidator<LoginRequestModel>
    {
        public LoginRequestModelValidator()
        {
            RuleFor(x => x.MailAddress)
                .NotEmpty()
                .WithMessage("Email alanı boş geçilemez.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre alanı boş geçilemez.");
        }
    }
}
