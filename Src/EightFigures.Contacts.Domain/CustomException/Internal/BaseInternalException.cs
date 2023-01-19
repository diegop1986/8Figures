using System.Net;

namespace EightFigures.Contacts.Domain.CustomException.Internal
{
    public abstract class BaseInternalException: BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

        public BaseInternalException() : base() { }

        public BaseInternalException(string message) : base(message) { }

        public BaseInternalException(string message, Exception innerException) : base(message, innerException) { }
    }
}
