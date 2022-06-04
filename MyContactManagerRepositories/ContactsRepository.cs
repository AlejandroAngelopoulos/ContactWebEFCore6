using ContactWebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerRepositories
{
    public class ContactsRepository : IContactsRepository
    {
        public Task<int> AddOrUpdateAsync(Contact Contact)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Contact Contact)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Contact>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Contact>> GetAllAsync(int? limit = null)
        {
            throw new NotImplementedException();
        }

        public Task<Contact?> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
