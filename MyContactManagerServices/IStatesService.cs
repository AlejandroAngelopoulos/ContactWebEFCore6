using ContactWebModels;
using MyContactManagerRepositories;

namespace MyContactManagerServices
{
    public interface IStatesService
    {
        Task<State?> GetAsync(int id);
        Task<IList<State>> GetAllAsync(int? limit = null);
        Task<int> AddOrUpdateAsync(State state);
        Task<int> DeleteAsync(State state);
        Task<int> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
