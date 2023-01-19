namespace EightFigures.Contacts.Service
{
    public interface ISettings
    {
        string EncryptionKey { get; }

        public string Key { get; }

        public string Issuer { get; }

        public string Audience { get; }

        public int ExpiryDurationMinutes { get; }
    }
}
