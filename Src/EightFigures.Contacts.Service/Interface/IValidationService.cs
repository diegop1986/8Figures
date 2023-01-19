namespace EightFigures.Contacts.Service.Interface
{
    public interface IValidationService
    {
        void EnsureValid<TType>(TType model);
    }
}
