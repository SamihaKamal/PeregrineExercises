using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRank.Integration.Tests.Setup
{
    public class TestContext : IAsyncLifetime
    {
        private readonly DockerClient _client;
        private const string ContainerImageUri = "amazon/dynamodb-local";
        private string _containerId;

        public TestContext()
        {
            _client = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();
        }
        public async Task InitializeAsync()
        {
            await PullImage();
            await StartContainer();
            await new TestDataSetup().CreateTable();
        }

        private async Task PullImage()
        {
            await _client.Images.CreateImageAsync(new Docker.DotNet.Models.ImagesCreateParameters
            {
                FromImage = ContainerImageUri,
                Tag = "latest"
            },
            new AuthConfig(),
            new Progress<JSONMessage>());
        }

        private async Task StartContainer()
        {
            var response = await _client.Containers.CreateContainerAsync(new CreateContainerParameters
            {
                Image = ContainerImageUri,
                ExposedPorts = new Dictionary<string, EmptyStruct>
                {
                    {
                        "8000", default(EmptyStruct)
                    }
                },
                HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        {
                            "8000", new List<PortBinding>{new PortBinding { HostPort = "8000"} }
                        }
                    },
                    PublishAllPorts = true
                }
            });

            _containerId = response.ID;
            await _client.Containers.StartContainerAsync(_containerId, null);
        }

        public async Task DisposeAsync()
        {
            if (_containerId != null)
            {
                await _client.Containers.KillContainerAsync(_containerId, new ContainerKillParameters());
            }
        }
    }
}
