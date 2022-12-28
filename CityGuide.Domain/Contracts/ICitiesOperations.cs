using CityGuide.Domain.Models;

namespace CityGuide.Domain.Contracts
{
    public interface ICitiesOperations
    {
        CityResponseModel GetCities();
    }
}
