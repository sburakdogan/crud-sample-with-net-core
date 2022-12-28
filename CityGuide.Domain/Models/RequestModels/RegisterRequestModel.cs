using System;

namespace CityGuide.Domain.Models
{
    public class RegisterRequestModel
    {
        public string Name { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public string Avatar { get; set; }
    }
}
