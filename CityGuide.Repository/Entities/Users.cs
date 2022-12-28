using System;
using System.Collections.Generic;

namespace CityGuide.Repository.Entities
{
    public partial class Users
    {
        public Users()
        {
            UserCities = new HashSet<UserCities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string MailAddress { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<UserCities> UserCities { get; set; }
    }
}
