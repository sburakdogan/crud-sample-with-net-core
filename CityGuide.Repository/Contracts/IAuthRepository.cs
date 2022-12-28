using CityGuide.Repository.Entities;

namespace CityGuide.Repository
{
    public interface IAuthRepository
    {
        Users UserByEmailAddress(string mailAddress);

        bool CheckEmailExist(string mailAddress);

        void Register(Users user);
    }
}
