using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

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
            _ = ServiceProvider.GetRequiredService<IApiDescriptionGroupCollectionProvider>();

            // Assert
        }

        [Fact]
        public void ServiceProvider_ResolvesSwashbuckle()
        {
            // Arrange

            // Act
            _ = ServiceProvider.GetRequiredService<ISwaggerProvider>();

            // Assert
        }
    }
}