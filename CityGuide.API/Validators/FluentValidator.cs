using CityGuide.Exc.Exceptions;
using FluentValidation;
using System;
using System.Linq;

namespace CityGuide.API.Validators
{
    public class FluentValidator
    {
        public void ValidateAndThrowException<Validator, Request>(Request request) where Validator : AbstractValidator<Request>
        {
            var validator = (Validator)Activator.CreateInstance(typeof(Validator));

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new BadRequestCustomException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            }
        }
    }
}
