using CityGuide.Domain.Models.ResponseModels;

namespace CityGuide.Domain.Contracts
{
    public interface ITownsOperations
    {
        TownResponseModel GetTownsByCityId(int cityId);
    }
}
