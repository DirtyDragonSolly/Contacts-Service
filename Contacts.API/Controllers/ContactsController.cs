using Contacts.Core.Abstractions;
using Contacts.Core.Models.Requests;
using Contacts.Core.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Contacts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetAllContactsResponse), 200)]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactsService.GetAllContactsAsync();

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetContactResponse), 200)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var contact = await _contactsService.GetContactAsync(id);

            return Ok(contact);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        public async Task<IActionResult> Create([FromBody, Required] CreateContactRequest request)
        {
            var contactId = await _contactsService.CreateContactAsync(request);

            return Ok(contactId);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Update([FromBody, Required] UpdateContactRequest request)
        {
            await _contactsService.UpdateContactAsync(request);

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Guid), 200)]
        public async Task<IActionResult> Delete([FromBody, Required] DeleteContactRequest request)
        {
            var contactId = await _contactsService.DeleteContactAsync(request);

            return Ok(contactId);
        }
    }
}
