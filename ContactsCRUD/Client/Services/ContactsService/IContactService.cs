namespace ContactsCRUD.Client.Services.ContactsService
{
    public interface IContactService
    {
        List<Contact> Contacts { get;set; }
        List<Category> Categories { get; set; }

        Task GetCategories();

        Task GetContacts();

        Task<Contact> GetSingleContact(int id);
    }
}
