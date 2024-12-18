using AutoMapper;
using Contacts.Core.Abstractions;
using Contacts.Core.Models.Entities;
using Contacts.Core.Models.Requests;
using Contacts.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsContext _context;
        private readonly IMapper _mapper;

        public ContactsRepository(ContactsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateContactRequest request)
        {
            var entity = _mapper.Map<ContactEntity>(request);
            entity.Id = Guid.NewGuid();

            await _context.Contacts.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            var contactEntities = await _context.Contacts
                .AsNoTracking()
                .Where(c => c.IsActive)
                .ToListAsync();

            var contacts = _mapper.Map<List<Contact>>(contactEntities);

            return contacts;
        }

        public async Task<Contact> GetAsync(Guid id)
        {
            var contactEntity = await ValidateContactAsync(id);

            return _mapper.Map<Contact>(contactEntity);
        }

        public async Task UpdateAsync(UpdateContactRequest request)
        {
            await ValidateContactAsync(request.Id);

            var entity = _mapper.Map<ContactEntity>(request);

            await _context.Contacts.Where(c => c.Id == entity.Id)
                .ExecuteUpdateAsync(updates => updates
                    .SetProperty(c => c.Name, entity.Name)
                    .SetProperty(c => c.Number, entity.Number));
        }

        public async Task<Guid> DeleteAsync(DeleteContactRequest request)
        {
            await ValidateContactAsync(request.Id);

            await _context.Contacts.Where(c => c.Id == request.Id && c.IsActive)
                .ExecuteUpdateAsync(updates => updates
                    .SetProperty(c => c.IsActive, false));

            return request.Id;
        }

        private async Task<ContactEntity> ValidateContactAsync(Guid id)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);

            if (contact == null)
            {
                throw new Exception("Contact not found");
            }

            if (!contact.IsActive) 
            { 
                throw new Exception("Contact not active");
            }

            return contact;
        }
    }
}
