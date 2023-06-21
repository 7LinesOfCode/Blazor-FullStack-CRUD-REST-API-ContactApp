using ContactsCRUD.Shared;
using System.Net.Http.Json;


namespace ContactsCRUD.Client.Services.ContactsService
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _http;

        public ContactService(HttpClient http)
        {
            _http= http;
        }

        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task CreateContact(Contact contact)
        {
            var result = await _http.PostAsJsonAsync("api/contact", contact);
            var response = await result.Content.ReadFromJsonAsync<List<Contact>>();
            Contacts = response;
        }

        public async Task DeleteContact(int id)
        {
            var result = await _http.DeleteAsync($"api/contact/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<Contact>>();
            Contacts = response;
        }

        public async Task GetCategories()
        {
            var result = await _http.GetFromJsonAsync<List<Category>>("api/contact/categories");
            if (result is not null)
            {
                Categories = result;
            }
        }

        public async Task GetContacts()
        {
            var result = await _http.GetFromJsonAsync<List<Contact>>("api/contact");
            if(result is not null)
            {
                Contacts = result;
            }
        }

        public async Task<Contact> GetSingleContact(int id)
        {
            var result = await _http.GetFromJsonAsync<Contact>($"api/contact/{id}");
            if (result is not null)
            {
                return result;
            }
            else
            {
                throw new Exception("Contact not found!");
            }
        }

        public async Task UpdateContact(Contact contact)
        {
            var result = await _http.PutAsJsonAsync($"api/contact/{contact.Id}", contact);
            var response = await result.Content.ReadFromJsonAsync<List<Contact>>();
            Contacts = response;
        }
    }
}
