using CityGuide.Domain.Contracts;
using CityGuide.Domain.Mapster;
using CityGuide.Domain.Models;
using CityGuide.Repository;
using CityGuide.Repository.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CityGuide.Domain
{
    public class CitiesOperations : ICitiesOperations
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IMapper _mapper;

        public CitiesOperations(ICitiesRepository citiesRepository, IMapper mapper)
        {
            _citiesRepository = citiesRepository;
            _mapper = mapper;
        }

        public CityResponseModel GetCities()
        {
            var cities = _citiesRepository.GetCities().ToList();

            var citiesDto = _mapper.Map<List<Cities>, List<CitiesDto>>(cities);

            return new CityResponseModel()
            {
                Cities = citiesDto
            };
        }
    }
}
