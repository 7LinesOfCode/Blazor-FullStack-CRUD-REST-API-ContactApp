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

        public Task GetCategories()
        {
            throw new NotImplementedException();
        }

        public async Task GetContacts()
        {
            var result = await _http.GetFromJsonAsync<List<Contact>>("api/contact");
            if(result is not null)
            {
                Contacts = result;
            }
        }

        public Task<Contact> GetSingleContact(int id)
        {
            throw new NotImplementedException();
        }
    }
}
