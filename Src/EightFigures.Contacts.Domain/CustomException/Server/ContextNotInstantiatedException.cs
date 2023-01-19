namespace EightFigures.Contacts.Domain.CustomException.Server
{
    public class ContextNotInstantiatedException: BaseServerException
    {
        public ContextNotInstantiatedException(): base("Context could not be instantiated") { }
    }
}
