using MovieRank.Libs.Repositories;

namespace MovieRank.Services
{
    public class SetupService : ISetupService
    {

        private readonly IMovieRankRepository _movieRankRepository;

        public SetupService(IMovieRankRepository repo)
        {
            _movieRankRepository = repo;
        }

        public async Task CreatDynamoDbTable(string tablename)
        {
            await _movieRankRepository.CreateDynamoDbTable(tablename);
        }

        public async Task DeleteDynamoDbTable(string tablename)
        {
            await _movieRankRepository.DeleteDynamoDbTable(tablename);
        }
    }
}
