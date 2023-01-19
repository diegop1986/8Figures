using System.Net;

namespace EightFigures.Contacts.Domain.CustomException.Business
{
    public abstract class BaseBusinessException : BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public BaseBusinessException() : base() { }

        public BaseBusinessException(string message) : base(message) { }

        public BaseBusinessException(string message, Exception innerException) : base(message, innerException) { }
    }
}
