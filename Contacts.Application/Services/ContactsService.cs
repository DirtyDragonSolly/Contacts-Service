using Contacts.Core.Abstractions;
using Contacts.Core.Models.Entities;
using Contacts.Core.Models.Requests;
using Contacts.Core.Models.Responses;

namespace Contacts.Application.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _repository;

        public ContactsService(IContactsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreateContactAsync(CreateContactRequest request)
        {
            return await _repository.CreateAsync(request);
        }

        public async Task<GetAllContactsResponse> GetAllContactsAsync()
        {
            var contacts = await _repository.GetAllAsync();

            var response = new GetAllContactsResponse
            {
                Contacts = contacts.Select(c =>
                {
                    var contact = new GetContactResponse
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Number = c.Number
                    };

                    return contact;
                }).ToList()
            };

            return response;
        }

        public async Task<GetContactResponse> GetContactAsync(Guid id)
        {
            var contact = await _repository.GetAsync(id);

            var response = new GetContactResponse
            {
                Id = contact.Id,
                Name = contact.Name,
                Number = contact.Number
            };

            return response;
        }

        public async Task UpdateContactAsync(UpdateContactRequest request)
        {
            await _repository.UpdateAsync(request);
        }

        public async Task<Guid> DeleteContactAsync(DeleteContactRequest request)
        {
            return await _repository.DeleteAsync(request);
        }
    }
}
