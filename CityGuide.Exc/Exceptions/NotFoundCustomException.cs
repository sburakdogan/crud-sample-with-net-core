using System.Net;

namespace CityGuide.Exc.Exceptions
{
    public class NotFoundCustomException : BaseCustomException
    {
        public NotFoundCustomException(string message) : base(message, (int)HttpStatusCode.NotFound)
        {
        }
    }
}
