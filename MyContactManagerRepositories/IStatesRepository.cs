using ContactWebModels;

namespace MyContactManagerRepositories
{
    public interface IStatesRepository
    {

        Task<State?> GetAsync(int id);
        Task<IList<State>> GetAllAsync();
        Task<int> AddOrUpdateAsync(State state);
        Task<int> DeleteAsync(State state);
        Task<int> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);



    }
}