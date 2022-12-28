using CityGuide.Domain.Contracts;
using CityGuide.Domain.Mapster;
using CityGuide.Domain.Models;
using CityGuide.Domain.Models.ResponseModels;
using CityGuide.Repository.Contracts;
using CityGuide.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CityGuide.Domain
{
    public class TownsOperations : ITownsOperations
    {
        private readonly ITownsRepository _townsRepository;
        private readonly IMapper _mapper;

        public TownsOperations(ITownsRepository townsRepository, IMapper mapper)
        {
            _townsRepository = townsRepository;
            _mapper = mapper;
        }

        public TownResponseModel GetTownsByCityId(int cityId)
        {
            var towns = _townsRepository.GetTownsByCityId(cityId).ToList();

            var townsDto = _mapper.Map<List<Towns>, List<TownsDto>>(towns);

            return new TownResponseModel
            {
                Towns = townsDto
            };
        }
    }
}
