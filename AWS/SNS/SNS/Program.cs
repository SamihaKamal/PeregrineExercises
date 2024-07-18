using Amazon.Extensions.NETCore.Setup;
using Amazon.SimpleNotificationService;
using Microsoft.AspNetCore.Builder;

namespace SNS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            AWSOptions aws = builder.Configuration.GetAWSOptions();
            builder.Services.AddDefaultAWSOptions(aws);
            builder.Services.AddAWSService<IAmazonSimpleNotificationService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwagger();
            }

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
