using System.ComponentModel.DataAnnotations;

namespace Contacts.Core.Models.Requests
{
    public class CreateContactRequest
    {
        [MinLength(11)]
        [MaxLength(11)]
        public required string Number { get; set; }

        [MinLength(0)]
        [MaxLength(25)]
        public required string Name { get; set; }
    }
}
