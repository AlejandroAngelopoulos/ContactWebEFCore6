using ContactWebModels;

namespace MyContactManagerRepositories
{
    public interface IStatesRepository
    {

        Task<IList<State>> GetAll();
        Task<State?> GetAsync();
        Task<IList<State>> GetAllAsync(int? limit = null);
        Task<int> AddOrUpdateAsync(State state);
        Task<int> DeleteAsync(State state);
        Task<int> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);



    }
}