using System.Net;

namespace EightFigures.Contacts.Domain.CustomException.NotFound
{
    public abstract class BaseNotFoundException : BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public BaseNotFoundException() : base() { }

        public BaseNotFoundException(string message) : base(message) { }

        public BaseNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
