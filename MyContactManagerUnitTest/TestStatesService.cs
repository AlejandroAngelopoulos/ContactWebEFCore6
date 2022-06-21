using Moq;
using MyContactManagerRepositories;
using MyContactManagerServices;
using ContactWebModels;

namespace MyContactManagerUnitTest
{
    public class TestStatesService
    {

        private IStatesService _stateService;
        private Mock<IStatesRepository> _repository;
        private int NUMBER_OF_STATES = 2;

        public TestStatesService()
        {
            CreateMocks();
        }

        private void CreateMocks()
        {
            _repository = new Mock<IStatesRepository>();
            var states = GetStatesTestData();
            var singleState = GetSingleState();

            _repository.Setup(x => x.GetAllAsync()).Returns((Delegate)states);
            _repository.Setup(x => x.GetAsync(It.IsAny<int>())).Returns((Task<State>)singleState);


        }

        private async Task<IList<State>> GetStatesTestData()
        {
            return new List<State>()
            {
                new State() { Id = 1, Name = "Attica", Abbreviation = "AT" },
                new State() { Id = 2, Name = "Achaia", Abbreviation = "AC" }
            };
        }

        private Task<IList<State>> GetSingleState()
        {
           
        }

       

        [Fact]
        public void Test1()
        {

        }
    }
}