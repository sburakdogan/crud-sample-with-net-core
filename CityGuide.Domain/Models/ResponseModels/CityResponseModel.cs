using System.Collections.Generic;

namespace CityGuide.Domain.Models
{
    public class CityResponseModel : BaseResponseModel
    {
        public List<CitiesDto> Cities { get; set; }
    }
}
