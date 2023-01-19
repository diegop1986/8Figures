using System.Text;

namespace EightFigures.Contacts.Domain.Extension
{
    public static class EncryptExtensions
    {
        public static string Encrypt(this string value, string key)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            value += key;
            var valueBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(valueBytes);
        }

        public static string Decrypt(this string value, string key)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            var encryptedValue = Convert.FromBase64String(value);
            var decryptedValue = Encoding.UTF8.GetString(encryptedValue);
            return decryptedValue.Substring(0, decryptedValue.Length - key.Length);
        }
    }
}
