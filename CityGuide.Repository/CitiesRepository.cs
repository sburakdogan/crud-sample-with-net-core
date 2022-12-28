using CityGuide.Repository.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CityGuide.Repository
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly CityGuideContext _context;

        public CitiesRepository(CityGuideContext cityGuideContext)
        {
            _context = cityGuideContext;
        }

        public IEnumerable<Cities> GetCities()
        {
            return _context.Cities;
        }

        public Cities GetCitiesById(int id)
        {
            return _context.Cities.FirstOrDefault(x => x.Id == id);
        }
    }
}
