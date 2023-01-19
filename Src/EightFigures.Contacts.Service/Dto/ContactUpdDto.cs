namespace EightFigures.Contacts.Service.Dto
{
    public class ContactUpdDto: BaseDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
