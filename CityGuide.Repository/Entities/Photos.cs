using System;
using System.Collections.Generic;

namespace CityGuide.Repository.Entities
{
    public partial class Photos
    {
        public int Id { get; set; }
        public int UserCityId { get; set; }
        public bool IsMain { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual UserCities UserCity { get; set; }
    }
}
