using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRank.Integration.Tests.Setup
{
    public class CustomWebApplicationFactory<TProgram> :WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(Services =>
            Services.AddSingleton<IAmazonDynamoDB>(GCCollectionMode =>
            {
                var clientConfig = new AmazonDynamoDBConfig { ServiceURL = "http://localhost:8000" };
                return new AmazonDynamoDBClient(clientConfig);
            }));
        }
    }
}
