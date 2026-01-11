using ModernStackLab.Models;
using ModernStackLab.Services;
using Microsoft.AspNetCore.Mvc;

namespace ModernStackLab.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // This makes the URL "api/contacts"
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        // Dependency Injection: We ask for the "Menu" (Interface)
        // ASP.NET automatically gives us the "Kitchen" (Service)
        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet] // GET: api/contacts
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _service.GetAllAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")] // GET: api/contacts/5
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _service.GetByIdAsync(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPost] // POST: api/contacts
        public async Task<IActionResult> Create(Contact contact)
        {
            await _service.CreateAsync(contact);
            return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
        }

        [HttpDelete("{id}")] // DELETE: api/contacts/5
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
