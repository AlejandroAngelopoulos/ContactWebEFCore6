using ContactWebModels;

namespace MyContactManagerServices
{
    public class StatesServices : IStatesServices
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