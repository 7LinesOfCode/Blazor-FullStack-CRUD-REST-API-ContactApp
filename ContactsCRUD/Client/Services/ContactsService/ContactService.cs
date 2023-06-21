using ContactsCRUD.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;


namespace ContactsCRUD.Client.Services.ContactsService
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ContactService(HttpClient http, NavigationManager navigationManager)
        {
            _http= http;
            _navigationManager = navigationManager;
        }

        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task CreateContact(Contact contact)
        {
            var result = await _http.PostAsJsonAsync("api/contact", contact);
            await SetContact(result);
        }

        private async Task SetContact(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Contact>>();
            Contacts = response;
            _navigationManager.NavigateTo("contacts");
        }

        public async Task DeleteContact(int id)
        {
            var result = await _http.DeleteAsync($"api/contact/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<Contact>>();
            await SetContact(result);
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
            await SetContact(result);
        }
    }
}
