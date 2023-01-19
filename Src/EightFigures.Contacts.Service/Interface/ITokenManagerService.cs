namespace EightFigures.Contacts.Service.Interface
{
    public interface ITokenManagerService
    {
        (string, DateTime) GenerateToken(string logIn, int id);
    }
}
