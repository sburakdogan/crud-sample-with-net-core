using CityGuide.API.Validators;
using CityGuide.Domain.Contracts;
using CityGuide.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CityGuide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthOperations _authOperations;
        private readonly FluentValidator _validator;

        public AuthController(IAuthOperations authOperations, FluentValidator validator)
        {
            _authOperations = authOperations;
            _validator = validator;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestModel loginRequestModel)
        {
            try
            {
                _validator.ValidateAndThrowException<LoginRequestModelValidator, LoginRequestModel>(loginRequestModel);

                var response = _authOperations.Login(loginRequestModel);

                return Ok(new LoginResponseModel
                {
                    Message = "Login işlemi başarılı.",
                    Token = response.Token,
                });
            }

            catch (Exception exc)
            {
                throw exc;
            }       
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequestModel registerRequestModel)
        { 
            try
            {
                _validator.ValidateAndThrowException<RegisterRequestModelValidator, RegisterRequestModel>(registerRequestModel);

                var response = _authOperations.Register(registerRequestModel);

                return Ok(new RegisterResponseModel
                {
                    Message = "Kayıt başarılı.",
                    UserId = response.UserId
                });
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
