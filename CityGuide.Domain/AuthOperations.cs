using CityGuide.Domain.Contracts;
using CityGuide.Domain.Helper;
using CityGuide.Domain.Models;
using CityGuide.Exc.Exceptions;
using CityGuide.Repository;
using CityGuide.Repository.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CityGuide.Domain
{
    public class AuthOperations : IAuthOperations
    {
        private readonly IAuthRepository _authRepository;
        private readonly ICitiesRepository _citiesRppository;
        private readonly IConfiguration _configuration;

        public AuthOperations(IAuthRepository authRepository, ICitiesRepository citiesRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _citiesRppository = citiesRepository;
            _configuration = configuration;
        }

        public LoginResponseModel Login(LoginRequestModel loginRequestModel)
        {
            var user = _authRepository.UserByEmailAddress(loginRequestModel.MailAddress);

            if (user == null)
            {
                throw new UnauthorizedCustomException("Kullanıcı bilgileri hatalı.");
            }

            if (!AuthHelper.VerifyPasswordHash(loginRequestModel.Password, user.Password, user.Salt))
            {
                throw new UnauthorizedCustomException("Kullanıcı bilgileri hatalı.");
            }

            var secretKey = Encoding.ASCII.GetBytes(_configuration.GetSection("Appsettings:Token").Value);

            var token = AuthHelper.CreateToken(secretKey, user);

            return new LoginResponseModel
            {
                Token = token
            };
        }
   
        public RegisterResponseModel Register(RegisterRequestModel registerRequestModel)
        {
            var isExist = _authRepository.CheckEmailExist(registerRequestModel.MailAddress);

            if (isExist)
            {
                throw new AlreadyExistCustomException("Bu mail adresi kullanımda.");
            }

            AuthHelper.CreatePasswordHash(registerRequestModel.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new Users
            {
                Name = registerRequestModel.Name,
                MailAddress = registerRequestModel.MailAddress,
                CreatedOn = DateTime.Now,
                Password = passwordHash,
                Salt = passwordSalt,
                Gender = registerRequestModel.Gender,
                BirthDate = registerRequestModel.BirthDate,
                IsActive = true,
            };

            _authRepository.Register(user);

            return new RegisterResponseModel
            {
                UserId = user.Id
            };
        }
    }
}
