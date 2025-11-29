using System.Net.Http.Json;
using Xunit;
using MeshAligner.Core;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MeshAligner.Infrastructure;

namespace MeshAligner.Api.Tests {
    public class MeshControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>> {
        private readonly HttpClient _client;
        private readonly MeshDbContext _dbContext;

        public MeshControllerIntegrationTests(WebApplicationFactory<Program> factory) {
            _client = factory.WithWebHostBuilder(builder => {
                builder.ConfigureServices(services => {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<MeshDbContext>));
                    if (descriptor != null) services.Remove(descriptor);
                    services.AddDbContext<MeshDbContext>(options =>
                        options.UseInMemoryDatabase(""TestDb""));
                });
            }).CreateClient();

            var scope = factory.Services.CreateScope();
            _dbContext = scope.ServiceProvider.GetRequiredService<MeshDbContext>();
        }

        [Fact]
        public async void Can_Create_And_Get_Mesh() {
            var mesh = new Mesh { Id = 1, Name = ""TestMesh"" };
            var response = await _client.PostAsJsonAsync(""/api/mesh"", mesh);
            response.EnsureSuccessStatusCode();

            var meshes = await _client.GetFromJsonAsync<Mesh[]>(""/api/mesh"");
            Assert.Contains(meshes, m => m.Id == 1 && m.Name == ""TestMesh"");
        }

        [Fact]
        public async void Can_Update_Mesh() {
            _dbContext.Meshes.Add(new Mesh { Id = 2, Name = ""OldName"" });
            _dbContext.SaveChanges();

            var updated = new Mesh { Id = 2, Name = ""NewName"" };
            var response = await _client.PutAsJsonAsync(""/api/mesh/2"", updated);
            response.EnsureSuccessStatusCode();

            var mesh = _dbContext.Meshes.Find(2);
            Assert.Equal(""NewName"", mesh.Name);
        }

        [Fact]
        public async void Can_Delete_Mesh() {
            _dbContext.Meshes.Add(new Mesh { Id = 3, Name = ""ToDelete"" });
            _dbContext.SaveChanges();

            var response = await _client.DeleteAsync(""/api/mesh/3"");
            response.EnsureSuccessStatusCode();

            var mesh = _dbContext.Meshes.Find(3);
            Assert.Null(mesh);
        }
    }
}
