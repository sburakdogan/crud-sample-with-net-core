using System;

namespace CityGuide.Exc
{
    public class BaseCustomException : Exception
    {
        public int Code { get; }

        public BaseCustomException(string message, int code) : base(message)
        {
            Code = code;
        }
    }
}
