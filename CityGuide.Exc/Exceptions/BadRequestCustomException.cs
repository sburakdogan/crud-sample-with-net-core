using System.Net;

namespace CityGuide.Exc.Exceptions
{
    public class BadRequestCustomException : BaseCustomException
    {
        public BadRequestCustomException(string message) : base(message, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}
