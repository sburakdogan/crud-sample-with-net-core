using CityGuide.Domain.Models;

namespace CityGuide.Domain.Contracts
{
    public interface IAuthOperations
    {
        LoginResponseModel Login(LoginRequestModel loginRequestModel);

        RegisterResponseModel Register(RegisterRequestModel registerRequestModel);
    }
}
