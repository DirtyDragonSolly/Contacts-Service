using Contacts.Core.Models.Requests;
using Contacts.Core.Models.Responses;

namespace Contacts.Core.Abstractions
{
    public interface IContactsService
    {
        Task<Guid> CreateContactAsync(CreateContactRequest request);
        Task<GetAllContactsResponse> GetAllContactsAsync();
        Task<GetContactResponse> GetContactAsync(Guid id);
        Task UpdateContactAsync(UpdateContactRequest request);
        Task<Guid> DeleteContactAsync(DeleteContactRequest request);

    }
}
