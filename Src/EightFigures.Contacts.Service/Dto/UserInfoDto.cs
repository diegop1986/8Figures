namespace EightFigures.Contacts.Service.Dto
{
    public class UserInfoDto
    {
        internal int UserId { get; set; }

        public string LogIn { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public DateTime? TokenExpiration { get; set; }
    }
}
