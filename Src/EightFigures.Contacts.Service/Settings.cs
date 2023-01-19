using Microsoft.Extensions.Configuration;

namespace EightFigures.Contacts.Service
{
    public class Settings: ISettings
    {
        private IConfiguration Config { get; }

        public Settings(IConfiguration config) => Config = config;

        public string EncryptionKey => Config["EncryptionKey"];

        public string Key => Config["Jwt:Key"];

        public string Issuer => Config["Jwt:Issuer"];

        public string Audience => Config["Jwt:Audience"];

        public int ExpiryDurationMinutes => int.Parse(Config["Jwt:ExpiryDurationMinutes"]);
    }
}
