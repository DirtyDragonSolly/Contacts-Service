using Contacts.Core.Models.Entities;
using Contacts.Core.Models.Requests;

namespace Contacts.Core.Abstractions
{
    public interface IContactsRepository
    {
        Task<Guid> CreateAsync(CreateContactRequest request);
        Task<List<Contact>> GetAllAsync();
        Task<Contact> GetAsync(Guid id);
        Task UpdateAsync(UpdateContactRequest request);
        Task<Guid> DeleteAsync(DeleteContactRequest request);
    }
}
