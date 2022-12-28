using System;
using System.Collections.Generic;

namespace CityGuide.Repository.Entities
{
    public partial class Towns
    {
        public Towns()
        {
            UserCities = new HashSet<UserCities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual Cities City { get; set; }
        public virtual ICollection<UserCities> UserCities { get; set; }
    }
}
