using System.Net;

namespace CityGuide.Exc.Exceptions
{
    public class AlreadyExistCustomException : BaseCustomException
    {
        public AlreadyExistCustomException(string message) : base(message, (int)HttpStatusCode.Conflict)
        {
        }
    }
}
