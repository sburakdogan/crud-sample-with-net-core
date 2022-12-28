using CityGuide.Domain.Models;
using FluentValidation;

namespace CityGuide.API.Validators
{
    public class RegisterRequestModelValidator : AbstractValidator<RegisterRequestModel>
    {
        public RegisterRequestModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("İsim alanı boş geçilemez.");

            RuleFor(x => x.MailAddress)
                .NotEmpty()
                .WithMessage("Email alanı boş geçilemez.");

            RuleFor(x => x.MailAddress)
                .EmailAddress()
                .WithMessage("Hatalı mail formatı.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre alanı boş geçilemez.");

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .WithMessage("Şifreniz en az 8 karakterden oluşmalıdır.");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("Doğum tarihi alanı boş geçilemez.");

            RuleFor(x => x.Gender)
                .InclusiveBetween(0,1)
                .WithMessage("Geçersiz cinsiyet.");
        }
    }
}
