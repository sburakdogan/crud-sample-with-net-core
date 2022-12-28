using CityGuide.Repository.Contracts;
using CityGuide.Repository.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CityGuide.Repository
{
    public class TownsRepository : ITownsRepository
    {
        private readonly CityGuideContext _context;

        public TownsRepository(CityGuideContext context)
        {
            _context = context;
        }

        public IEnumerable<Towns> GetTownsByCityId(int cityId)
        {
            return _context.Towns.Where(x => x.CityId == cityId);
        }
    }
}
