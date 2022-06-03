using FluentAssertions;
using SmartWorkout_Backend.Communication;
using SmartWorkout_Backend.Resources;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace SmartWorkout_Backend.Tests.Exercise
{
    public class ExerciseControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAllExercises_ReturnNotNull()
        {
            await AunthenticateAsync();

            var response = await TestClient.GetAsync(ApiRoutes.Exercise.GetAllExercises);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            (await JsonSerializer.DeserializeAsync<ApiResponse<List<ExerciseResource>>>(await response.Content.ReadAsStreamAsync()))
                .Should().NotBeNull();
        }

        [Fact]
        public async Task GetExerciseById_ReturnNotNull()
        {
            await AunthenticateAsync();

            var response = await TestClient.GetAsync(ApiRoutes.Exercise.GetExerciseById);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            (await JsonSerializer.DeserializeAsync<ApiResponse<ExerciseResource>>(await response.Content.ReadAsStreamAsync()))
                .Should().NotBeNull();
        }

        [Fact]
        public async Task GetFavoriteById_ReturnNotNull()
        {
            await AunthenticateAsync();

            var response = await TestClient.GetAsync(ApiRoutes.Exercise.GetFavoriteById);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            (await JsonSerializer.DeserializeAsync<ApiResponse<List<FavoriteExerciseResource>>>(await response.Content.ReadAsStreamAsync()))
                .Should().NotBeNull();
        }

        [Fact]
        public async Task GetRecommendId_ReturnNotNull()
        {
            await AunthenticateAsync();

            var response = await TestClient.GetAsync(ApiRoutes.Exercise.GetRecommendById);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            (await JsonSerializer.DeserializeAsync<ApiResponse<List<RecommendExerciseResource>>>(await response.Content.ReadAsStreamAsync()))
                .Should().NotBeNull();
        }
    }
}
