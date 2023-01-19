using System.Net;

namespace EightFigures.Contacts.Domain.CustomException
{
    public abstract class BaseException : Exception
    {
        public abstract HttpStatusCode StatusCode { get; }

        public BaseException() : base() { }

        public BaseException(string message) : base(message) { }

        public BaseException(string message, Exception innerException) : base(message, innerException) { }
    }
}
