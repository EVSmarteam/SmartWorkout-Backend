using FluentAssertions;
using SmartWorkout_Backend.Communication;
using SmartWorkout_Backend.Resources;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace SmartWorkout_Backend.Tests
{
    public class UserControllerTests : IntegrationTest
    {
        [Fact]
        public async Task Authenticate_ReturnsSuccessMessage()
        {
            await AunthenticateAsync();            
        }

        [Fact]
        public async Task Authenticate_ReturnsMessageError()
        {
            await AunthenticateAsync();
        }

        [Fact]
        public async Task GetAllUsers_ReturnNotNull()
        {
            await AunthenticateAsync();

            var response = await TestClient.GetAsync(ApiRoutes.Users.GetAllUsers);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            (await JsonSerializer.DeserializeAsync<ApiResponse<List<UserResource>>>(await response.Content.ReadAsStreamAsync()))
                .Should().NotBeNull();
        }

        [Fact]
        public async Task GetUserById_ReturnNotNull()
        {
            await AunthenticateAsync();

            var response = await TestClient.GetAsync(ApiRoutes.Users.GetUserById);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            (await JsonSerializer.DeserializeAsync<ApiResponse<UserResource>>(await response.Content.ReadAsStreamAsync()))
                .Should().NotBeNull();
        } 
    }
}