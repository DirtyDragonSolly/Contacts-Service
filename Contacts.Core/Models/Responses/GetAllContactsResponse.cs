using Contacts.Core.Models.Entities;

namespace Contacts.Core.Models.Responses
{
    public class GetAllContactsResponse
    {
        public List<GetContactResponse> Contacts { get; set; }
    }
}
