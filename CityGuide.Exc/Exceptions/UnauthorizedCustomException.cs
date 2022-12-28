using System.Net;

namespace CityGuide.Exc.Exceptions
{
    public class UnauthorizedCustomException : BaseCustomException
    {
        public UnauthorizedCustomException(string message) : base(message, (int) HttpStatusCode.Unauthorized)
        {

        }
    }
}
