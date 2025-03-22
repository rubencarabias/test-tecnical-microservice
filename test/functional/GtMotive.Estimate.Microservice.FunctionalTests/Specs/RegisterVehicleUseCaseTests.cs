using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.RegisterVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RegisterVehicle;
using GtMotive.Estimate.Microservice.Domain.Entities.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    [Collection(TestCollections.Functional)]
    public class RegisterVehicleUseCaseTests(CompositionRootTestFixture fixture) : FunctionalTestBase(fixture)
    {
        [Fact]
        public async Task RegisterVehicleIntegrationTestSuccess()
        {
            var vehicleId = Guid.Empty;

            await Fixture.UsingHandlerForRequestResponse<RegisterVehicleRequest, IWebApiPresenter>(async handler =>
            {
                var request = new RegisterVehicleRequest
                {
                    Model = "Toyota",
                    Brand = "Corolla",
                    ManufacturingDate = DateTime.UtcNow
                };

                var presenter = await handler.Handle(request, default);
                var objectResult = presenter.ActionResult as ObjectResult;
                var value = objectResult?.Value as RegisterVehicleOutput;

                vehicleId = value.VehicleId;

                Assert.NotNull(presenter);
                Assert.NotEqual(Guid.Empty, vehicleId);
                Assert.IsType<ObjectResult>(presenter.ActionResult);
            });

            await Fixture.UsingRepository<IVehicleRepository>(async repository =>
            {
                var vehicle = await repository.GetVehicleByIdAsync(new VehicleId(vehicleId));
                Assert.NotNull(vehicle);
            });
        }
    }
}
