using AutoMapper;
using Contacts.Core.Models.Entities;
using Contacts.Core.Models.Requests;
using Contacts.Core.Models.Responses;
using Contacts.Data.Entities;

namespace Contacts.Data.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ContactEntity, Contact>();
            CreateMap<CreateContactRequest,ContactEntity>();
            CreateMap<UpdateContactRequest, ContactEntity>();
        }
    }
}
