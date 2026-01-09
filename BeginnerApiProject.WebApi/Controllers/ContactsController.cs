using BeginnerApiProject.WebApi.Context;
using BeginnerApiProject.WebApi.Dtos.ContactDtos;
using BeginnerApiProject.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BeginnerApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ContactsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var contacts = _context.Contacts.ToList();
            return Ok(contacts);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact();
            contact.Email = createContactDto.Email;
            contact.Address = createContactDto.Address;
            contact.MapLocation = createContactDto.MapLocation;
            contact.OpenHours = createContactDto.OpenHours;
            contact.Phone = createContactDto.Phone;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok(contact);

        }
    }
}
