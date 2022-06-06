using ContactWebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerServices
{
    public class ContactsService : IContactsService
    {
        public async Task<int> AddOrUpdateAsync(Contact Contact)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(Contact Contact)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Contact>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Contact>> GetAllAsync(int? limit = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Contact?> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
