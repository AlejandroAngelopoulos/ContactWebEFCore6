using ContactWebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerRepositories
{
    public interface IContactsRepository
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
