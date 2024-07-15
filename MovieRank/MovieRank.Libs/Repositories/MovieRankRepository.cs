using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using MovieRank.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRank.Libs.Repositories
{
    public class MovieRankRepository : IMovieRankRepository
    {
        private readonly DynamoDBContext _context;

        public MovieRankRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _context = new DynamoDBContext(dynamoDbClient);
        }

        public async Task<IEnumerable<MovieDB>> GetAllItems()
        {
            return await _context.ScanAsync<MovieDB>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task<MovieDB> GetMovie(int userId, string movieName)
        {
            return await _context.LoadAsync<MovieDB>(userId, movieName);
        }

        public async Task<IEnumerable<MovieDB>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var config = new DynamoDBOperationConfig
            {
                QueryFilter = new List<ScanCondition>
                {
                    new ScanCondition("MovieName", Amazon.DynamoDBv2.DocumentModel.ScanOperator.BeginsWith, movieName)
                }
            };

            return await _context.QueryAsync<MovieDB>(userId, config).GetRemainingAsync();

        }

        public async Task AddMovie(MovieDB movieDb)
        {
            await _context.SaveAsync(movieDb);
        }
    }
}
