using Newtonsoft.Json;

namespace CityGuide.Domain.Models
{
    public class BaseResponseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }
}
