using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SmartWorkout_Backend.Connection;
using System.Net.Http.Json;
using SmartWorkout_Backend.Authentication;
using SmartWorkout_Backend.Communication;
using System.Text.Json;

namespace SmartWorkout_Backend.Tests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(SmartWorkoutDbContext));
                        services.AddDbContext<SmartWorkoutDbContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });
            TestClient = appFactory.CreateClient();
        }

        protected async Task AunthenticateAsync()
        {
            TestClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        private async Task<string> GetJwtAsync()
        {
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Users.Authenticate, new AuthenticateRequest
            {
                Email = "sergio.aqs17@gmail.com",
                Password = "4890609"
            });

            var registrationResponse = await JsonSerializer.DeserializeAsync<ApiResponse<AuthenticateResponse>>(await response.Content.ReadAsStreamAsync());
            if (response.IsSuccessStatusCode)
                return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiIxIiwiZW1haWwiOiJzZXJnaW8uYXFzMTdAZ21haWwuY29tIiwibmFtZSI6IlNlcmdpbyBRdWlyb3oiLCJuYmYiOjE2NTU0NjE2NTYsImV4cCI6MTY1NjA2NjQ1NiwiaWF0IjoxNjU1NDYxNjU2fQ.sffa2jKvf62yCjVltAZRlf7Ekjox0Mod7dX6XxGFQ4c";
            return registrationResponse.Data.Token;
        }
    }
}
