using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using MovieRank.Contracts;
using MovieRank.Libs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieRank.Libs.Repositories
{
    public class MovieRankRepository : IMovieRankRepository
    {
        private const string TableName = "MovieRank";
        private readonly IAmazonDynamoDB _client;

        public MovieRankRepository(IAmazonDynamoDB client)
        {
            _client = client;
        }

        public async Task<ScanResponse> GetAllItems()
        {
            var request = new ScanRequest(TableName);

            return await _client.ScanAsync(request);
        }

        public async Task<GetItemResponse> GetMovie(int userId, string movieName)
        {
            var request = new GetItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    {"UserId", new AttributeValue {N = userId.ToString()} },
                    {"MovieName", new AttributeValue{S = movieName} }
                }
            };

            return await _client.GetItemAsync(request);
        }

        public async Task<QueryResponse> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var request = new QueryRequest
            {
                TableName = TableName,
                KeyConditionExpression = "UserId = :userId and begins_with (MovieName, :movieName)",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                    {":userId", new AttributeValue {N = userId.ToString()} },
                    {":movieName", new AttributeValue{S = movieName} }
                }
            };

            return await _client.QueryAsync(request);
        }

        public async Task AddMovie(int userId, MovieRankRequest request)
        {
            var request2 = new PutItemRequest
            {
                TableName = TableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    {"UserId", new AttributeValue {N = userId.ToString()} },
                    {"MovieName", new AttributeValue{S = request.MovieName} },
                    {"Description", new AttributeValue {S = request.Description} },
                    {"Actors", new AttributeValue{SS = request.Actors} },
                    {"Ranking", new AttributeValue {N = request.Ranking.ToString()} },
                    {"RankedDateTime", new AttributeValue{S = DateTime.UtcNow.ToString()} }
                }
            };

            await _client.PutItemAsync(request2);
        }

        public async Task UpdateMovie(int userId, MovieUpdateRequest movieRequest)
        {
            var request = new UpdateItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "UserId", new AttributeValue { N = userId.ToString() } },
                    { "MovieName", new AttributeValue { S = movieRequest.MovieName } },
                },
                AttributeUpdates = new Dictionary<string, AttributeValueUpdate>
                {
                    {"Ranking", new AttributeValueUpdate
                    {
                        Action = AttributeAction.PUT,
                        Value = new AttributeValue{N = movieRequest.Ranking.ToString()}
                    }
                    },
                    {"RankedDateTime", new AttributeValueUpdate
                    {
                        Action = AttributeAction.PUT,
                        Value = new AttributeValue{S = DateTime.UtcNow.ToString()}
                    }
                    }
                }
            };

            await _client.UpdateItemAsync(request);
        }

        public async Task<QueryResponse> GetMovieRank(string movieName)
        {
            var request = new QueryRequest
            {
                TableName = TableName,
                IndexName = "MovieName-index",
                KeyConditionExpression = "MovieName = :movieName",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                {
                    {":movieName", new AttributeValue{ S = movieName} }
                }
            };

            return await _client.QueryAsync(request);
        }

        public async Task CreateDynamoDbTable(string tablename)
        {
            var request = new CreateTableRequest
            {
                TableName = tablename,
                AttributeDefinitions = new List<AttributeDefinition>()
                {
                    new AttributeDefinition
                    {
                        AttributeName = "Id",
                        AttributeType = "N"
                    }
                },
                KeySchema = new List<KeySchemaElement>()
                {
                    new KeySchemaElement
                    {
                        AttributeName = "Id",
                        KeyType = "HASH"
                    }
                },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 1,
                    WriteCapacityUnits = 1,
                }
            };

            await _client.CreateTableAsync(request);
        }

        public async Task DeleteDynamoDbTable(string tableName)
        {
            var request = new DeleteTableRequest
            {
                TableName = tableName,
            };

            await _client.DeleteTableAsync(request);
        }
    }
}
