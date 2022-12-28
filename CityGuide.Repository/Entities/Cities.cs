using System;
using System.Collections.Generic;

namespace CityGuide.Repository.Entities
{
    public partial class Cities
    {
        public Cities()
        {
            Towns = new HashSet<Towns>();
            UserCities = new HashSet<UserCities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Towns> Towns { get; set; }
        public virtual ICollection<UserCities> UserCities { get; set; }
    }
}
