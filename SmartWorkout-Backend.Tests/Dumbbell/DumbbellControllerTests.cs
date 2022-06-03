using FluentAssertions;
using SmartWorkout_Backend.Communication;
using SmartWorkout_Backend.Resources;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace SmartWorkout_Backend.Tests.Dumbbell
{
    public class DumbbellControllerTests : IntegrationTest
    { 
        [Fact]
        public async Task GetAllDumbbells_ReturnNotNull()
        {
            await AunthenticateAsync();

            var response = await TestClient.GetAsync(ApiRoutes.Dumbbell.GetAllDumbbell);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            (await JsonSerializer.DeserializeAsync<ApiResponse<List<DumbbellResource>>>(await response.Content.ReadAsStreamAsync()))
                .Should().NotBeNull();
        }

        [Fact]
        public async Task GetDumbbellById_ReturnNotNull()
        {
            await AunthenticateAsync();

            var response = await TestClient.GetAsync(ApiRoutes.Dumbbell.GetDumbbellById);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            (await JsonSerializer.DeserializeAsync<ApiResponse<DumbbellResource>>(await response.Content.ReadAsStreamAsync()))
                .Should().NotBeNull();
        }
    }
}
