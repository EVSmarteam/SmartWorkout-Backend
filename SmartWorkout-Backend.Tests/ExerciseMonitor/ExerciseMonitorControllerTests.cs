using FluentAssertions;
using SmartWorkout_Backend.Communication;
using SmartWorkout_Backend.Resources;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace SmartWorkout_Backend.Tests.ExerciseMonitor
{
    public class ExerciseMonitorControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAllExerciseMonitorsByUserId_ReturnNotNull()
        {
            await AunthenticateAsync();

            var response = await TestClient.GetAsync(ApiRoutes.ExerciseMonitor.GetExerciseMonitorId);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            (await JsonSerializer.DeserializeAsync<ApiResponse<List<ExerciseMonitorResource>>>(await response.Content.ReadAsStreamAsync()))
                .Should().NotBeNull();
        }

        [Fact]
        public async Task GetExerciseMonitorById_ReturnNotNull()
        {
            await AunthenticateAsync();

            var response = await TestClient.GetAsync(ApiRoutes.ExerciseMonitor.GetExerciseMonitorId);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            (await JsonSerializer.DeserializeAsync<ApiResponse<ExerciseMonitorResource>>(await response.Content.ReadAsStreamAsync()))
                .Should().NotBeNull();
        }
    }
}
