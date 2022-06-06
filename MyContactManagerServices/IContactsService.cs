using ContactWebModels;

namespace MyContactManagerServices
{
    public interface IContactsService
    {
        Task<IList<Contact>> GetAll();
        Task<Contact?> GetAsync();
        Task<IList<Contact>> GetAllAsync(int? limit = null);
        Task<int> AddOrUpdateAsync(Contact Contact);
        Task<int> DeleteAsync(Contact Contact);
        Task<int> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
