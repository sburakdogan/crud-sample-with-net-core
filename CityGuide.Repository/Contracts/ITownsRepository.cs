using CityGuide.Repository.Entities;
using System.Collections.Generic;

namespace CityGuide.Repository.Contracts
{
    public interface ITownsRepository
    {
        IEnumerable<Towns> GetTownsByCityId(int cityId);
    }
}
