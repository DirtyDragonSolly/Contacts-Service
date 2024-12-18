namespace Contacts.Core.Models.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }        
        public bool IsActive { get; set; } = true;
    }
}
