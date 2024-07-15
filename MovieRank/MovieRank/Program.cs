

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using MovieRank.Libs.Mappers;
using MovieRank.Libs.Repositories;
using MovieRank.Services;

namespace MovieRank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            builder.Services.AddAWSService<IAmazonDynamoDB>();
            builder.Services.AddDefaultAWSOptions(
                new AWSOptions
                {
                    Region = RegionEndpoint.GetBySystemName("eu-north-1")
                });
            builder.Services.AddSingleton<IMovieRankService, MovieRankService>();
            builder.Services.AddSingleton<IMovieRankRepository, MovieRankRepository>();
            builder.Services.AddSingleton<IMapper, Mapper>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
