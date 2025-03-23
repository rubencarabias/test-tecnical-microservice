using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.RegisterVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicleById;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RegisterVehicle;
using GtMotive.Estimate.Microservice.InfrastructureTests.Commun;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    [Collection(TestCollections.TestServer)]
    public class RegisterVehicleTest(GenericInfrastructureTestServerFixture fixture)
        : InfrastructureTestBase(fixture)
    {
        private readonly HttpClient _client = fixture.Server.CreateClient();
        private readonly string _vehiclesEndpoint = "/vehicles";

        [Fact]
        public async Task RegisterVehicleShouldAddVehicleToAvailableList()
        {
            // Arrange
            var request = new RegisterVehicleRequest
            {
                Model = "Toyota",
                Brand = "Corolla",
                ManufacturingDate = DateTime.UtcNow
            };

            // Act
            var registerResponse = await RegisterVehicleAsync(request);
            var addedVehicle = await GetAvailableVehiclesAsync(registerResponse.VehicleId);

            // Assert
            Assert.NotNull(registerResponse);
            Assert.NotNull(addedVehicle);
            Assert.Equal(registerResponse.VehicleId, addedVehicle.Id);
            Assert.Equal(request.Model, addedVehicle.Model);
            Assert.Equal(request.Brand, addedVehicle.Brand);
            Assert.Equal(request.ManufacturingDate.ToShortDateString(), addedVehicle.ManufacturingDate.ToShortDateString());
        }

        private async Task<RegisterVehicleOutput> RegisterVehicleAsync(RegisterVehicleRequest request)
        {
            using var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var uri = new Uri(_vehiclesEndpoint, UriKind.Relative);
            var response = await _client.PostAsync(uri, content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ApiResponse<RegisterVehicleOutput>>(responseJson, JsonSerializerOptionsFactory.Options).Data;
        }

        private async Task<GetVehicleByIdOutput> GetAvailableVehiclesAsync(Guid vehicleId)
        {
            var uri = new Uri($"{_vehiclesEndpoint}/{vehicleId}", UriKind.Relative);
            var response = await _client.GetAsync(uri);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseJson = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ApiResponse<GetVehicleByIdOutput>>(responseJson, JsonSerializerOptionsFactory.Options).Data;
        }
    }
}
