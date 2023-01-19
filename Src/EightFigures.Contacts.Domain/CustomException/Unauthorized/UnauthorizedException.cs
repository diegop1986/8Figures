using System.Net;

namespace EightFigures.Contacts.Domain.CustomException.Unauthorized
{
    public class UnauthorizedException: BaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

        public UnauthorizedException() { }
    }
}
