using System.Net.Http;
using System.Threading.Tasks;
using AspNetCoreTest201908;
using AspNetCoreTest201908.Model;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace E2ETests
{
    public class Lab00 : TestBase<Startup>
    {
        public Lab00(WebApplicationFactory<Startup> factory)
                : base(factory)
        {
        }

        [Fact]
        public async Task Test()
        {
            var httpClient = CreateHttpClient();

            var response = await httpClient.GetAsync("/api/Lab00/Index");

            response.EnsureSuccessStatusCode();

            var authResult = await response.Content.ReadAsAsync<AuthResult>();

            authResult.IsAuth.Should().BeTrue();
            authResult.Name.Should().Be("ABC");
        }
    }
}