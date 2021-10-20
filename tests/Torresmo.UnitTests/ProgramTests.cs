using FluentAssertions;

using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

using MonoTorrent.Client;

using Swashbuckle.AspNetCore.Swagger;

using System;

using Xunit;

namespace Torresmo.UnitTests
{
    public class ProgramTests : WebApplicationFactory<Program>
    {
        private IServiceProvider ServiceProvider => Server.Services;

        [Fact]
        public void ServiceProvider_ResolvesApiExplorer()
        {
            // Arrange

            // Act
            Action act = () => ServiceProvider.GetRequiredService<IApiDescriptionGroupCollectionProvider>();

            // Assert
            act.Should().NotThrow("the DI container should always have the Api Explorer services");
        }

        [Fact]
        public void ServiceProvider_ResolvesSwashbuckle()
        {
            // Arrange

            // Act
            Action act = () => ServiceProvider.GetRequiredService<ISwaggerProvider>();

            // Assert
            act
                .Should()
                .NotThrow("The DI container should always have the Swagger Generator, else there would be no OpenApi docs");
        }

        [Fact]
        public void ServiceProvider_ResolvesClientEngine()
        {
            // Arrange

            // Act
            Action act = () => ServiceProvider.GetRequiredService<ClientEngine>();

            // Assert
            act
                .Should()
                .NotThrow("The MonoTorrent.ClientEngine is the backing engine behind the API");
        }
    }
}