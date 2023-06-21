using ContactsCRUD.Server.Data;
using ContactsCRUD.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataContext _context;
        public ContactController(DataContext context)
        {
            _context= context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {
            var contacts = await _context.Contacts.Include(c => c.Category).ToListAsync();
            return Ok(contacts);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<Contact>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetSingleContact(int id)
        {
            var contact = await _context
                .Contacts
                .Include(c=>c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (contact is null)
            {
                return NotFound($"Contact with id:{id} not found");
            }
            else
            {
                return Ok(contact);
            }
            
        }


        [HttpPost]
        public async Task<ActionResult<List<Contact>>> CreateContact(Contact contact)
        {
            contact.Category = null;
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return Ok(await GetDbContacts());
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<List<Contact>>> UpdateContact(Contact contact, int id)
        {
            var dbContact = await _context.Contacts
                .Include(c=>c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (dbContact is null)
            {
                return NotFound("Not contact founded");
            }
            else
            {
                dbContact.FirstName = contact.FirstName;
                dbContact.LastName = contact.LastName;
                dbContact.PhoneNumber = contact.PhoneNumber;
                dbContact.Note = contact.Note;
                dbContact.CategoryId = contact.CategoryId;

                await _context.SaveChangesAsync();

                return Ok(await GetDbContacts());
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<Contact>>> UpdateContact(int id)
        {
            var dbContact = await _context.Contacts
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (dbContact is null)
            {
                return NotFound("Not contact founded");
            }
            else
            {
                _context.Contacts.Remove(dbContact);
                await _context.SaveChangesAsync();

                return Ok(await GetDbContacts());
            }
        }

        private async Task<List<Contact>> GetDbContacts()
        {
            return await _context.Contacts.Include(c=>c.Category).ToListAsync();
        }

    }
}
