using System;

namespace Data.Exceptions
{
    public class ApiErrorException : Exception
    {
        public ApiErrorException(string message) : base(message)
        {

        }
    }
}
