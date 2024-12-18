using System.ComponentModel.DataAnnotations;

namespace Contacts.Core.Models.Requests
{
    public class DeleteContactRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
