using System.Net;

namespace EightFigures.Contacts.Domain.CustomException.Server
{
    public abstract class BaseServerException : BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public BaseServerException() : base() { }

        public BaseServerException(string message) : base(message) { }

        public BaseServerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
