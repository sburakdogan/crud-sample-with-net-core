using CityGuide.Repository.Entities;
using System.Linq;

namespace CityGuide.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly CityGuideContext _context;

        public AuthRepository(CityGuideContext cityGuideContext)
        {
            _context = cityGuideContext;
        }

        public Users UserByEmailAddress(string mailAddress)
        {
            return _context.Users.FirstOrDefault(x => x.MailAddress == mailAddress);
        }

        public bool CheckEmailExist(string mailAddress)
        {
            return _context.Users.Any(x => x.MailAddress == mailAddress);
        }

        public void Register(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
