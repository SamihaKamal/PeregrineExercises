using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieRank.Integration.Tests.Setup
{
    public class TestDataSetup
    {
        private static readonly IAmazonDynamoDB client = new AmazonDynamoDBClient(new AmazonDynamoDBConfig
        {
            ServiceURL = "http://localhost:8000"
        });

        public async Task CreateTable()
        {
            var request = new CreateTableRequest
            {
                TableName = "MovieRank",
                AttributeDefinitions = new List<AttributeDefinition>()
                {
                    new AttributeDefinition
                    {
                        AttributeName = "UserId",
                        AttributeType = "N"
                    },
                    new AttributeDefinition
                    {
                        AttributeName = "MovieName",
                        AttributeType = "S"
                    },
                },
                KeySchema = new List<KeySchemaElement>()
                {
                    new KeySchemaElement
                    {
                        AttributeName = "UserId",
                        KeyType = "HASH"
                    },
                    new KeySchemaElement
                    {
                        AttributeName = "MovieName",
                        KeyType = "RANGE"
                    },

                },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 1,
                    WriteCapacityUnits = 1,
                },
                GlobalSecondaryIndexes = new List<GlobalSecondaryIndex>()
                {
                    new GlobalSecondaryIndex
                    {
                        IndexName = "MovieName-index",
                        KeySchema = new List<KeySchemaElement>
                        {
                            new KeySchemaElement
                            {
                                AttributeName = "MovieName",
                                KeyType = "HASH"
                            }
                        },
                        ProvisionedThroughput = new ProvisionedThroughput
                        {
                            ReadCapacityUnits = 1,
                            WriteCapacityUnits = 1
                        },
                        Projection = new Projection
                        {
                            ProjectionType = "ALL"
                        }
                    }
                }
            };

            await client.CreateTableAsync(request);
            await WaitTille(request.TableName);
        }

        private static async Task WaitTille(string tablename)
        {
            string status = null;
            do
            {
                Thread.Sleep(5000);
                try
                {
                    status = await getTableStatus(tablename);
                }
                catch (ResourceNotFoundException)
                {

                }
            } while (status != "ACTIVE");
        }

        private static async Task<string> getTableStatus(string tablename)
        {
            var response = await client.DescribeTableAsync(new DescribeTableRequest
            {
                TableName = tablename
            });

            return response.Table.TableStatus;
        }
    }
}
