using ContactsCRUD.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public static List<Category> categories = new List<Category>()
        {
            new Category {Id = 1, Name = "Private"},
            new Category {Id = 2, Name = "Work"},
            new Category {Id = 3, Name = "Other"},
        };

        public static List<Contact> contacts = new List<Contact>()
        {
            new Contact
            {
                Id = 1,
                FirstName ="Jan",
                LastName ="Brzechwa",
                PhoneNumber = "123 123 123",
                Category = categories[0],
                Note = "",  
            },
            new Contact
            {
                Id = 2,
                FirstName ="Net",
                LastName ="Pc",
                PhoneNumber = "123 123 123",
                Category = categories[1],
                Note = "",
            }
        };


        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Contact>>> GetSingleContact(int id)
        {
            var contact = contacts.FirstOrDefault(c=>c.Id ==id );
            if(contact is null)
            {
                return NotFound($"Contact with id:{id} not found");
            }
            else
            {
                return Ok(contact);
            }
            
        }

    }
}
