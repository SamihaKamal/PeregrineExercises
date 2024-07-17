using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2;
using MovieRank.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using MovieRank.Contracts;

namespace MovieRank.Libs.Repositories
{
    public interface IMovieRankRepository
    {
        Task<ScanResponse> GetAllItems();
        Task<GetItemResponse> GetMovie(int userId, string movieName);
        Task<QueryResponse> GetUsersRankedMoviesByMovieTitle(int userId, string movieName);
        Task AddMovie(int userId, MovieRankRequest request);
        Task UpdateMovie(int userId, MovieUpdateRequest movieRequest);
        Task<QueryResponse> GetMovieRank(string movieName);
        Task CreateDynamoDbTable(string tablename);
        Task DeleteDynamoDbTable(string tableName);
    }
}
