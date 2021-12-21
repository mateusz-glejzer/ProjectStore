using System;

namespace ProjectStore.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message):base(message)
        {

        }

    }

}
