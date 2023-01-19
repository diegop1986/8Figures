using System.Runtime.Serialization;

namespace EightFigures.Contacts.Service.Dto
{
    public class BaseDto
    {
        [IgnoreDataMember]
        public string? UserRequest { get; set; }

        [IgnoreDataMember]
        public int? UserId { get; set; }
    }
}
