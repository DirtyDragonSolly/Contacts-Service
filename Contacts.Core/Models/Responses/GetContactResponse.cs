namespace Contacts.Core.Models.Responses
{
    public class GetContactResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Number { get; set; }
    }
}
