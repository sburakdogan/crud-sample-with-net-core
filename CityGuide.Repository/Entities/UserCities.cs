using System;
using System.Collections.Generic;

namespace CityGuide.Repository.Entities
{
    public partial class UserCities
    {
        public UserCities()
        {
            Photos = new HashSet<Photos>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public int? TownId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual Cities City { get; set; }
        public virtual Towns Town { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Photos> Photos { get; set; }
    }
}
