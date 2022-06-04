using ContactWebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerRepositories
{
    public class StatesRepository : IStatesRepository
    {
        public async Task<int> AddOrUpdateAsync(State state)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(State state)
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

        public async Task<IList<State>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<State>> GetAllAsync(int? limit = null)
        {
            throw new NotImplementedException();
        }

        public async Task<State?> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
