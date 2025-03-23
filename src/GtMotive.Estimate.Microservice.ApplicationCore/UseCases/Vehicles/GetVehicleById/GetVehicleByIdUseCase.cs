using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicleById
{
    /// <summary>
    /// Use case to get all available vehicles.
    /// </summary>
    public class GetVehicleByIdUseCase(
        IVehicleRepository vehicleRepository,
        IGetVehicleByIdOutputPort outputPort) : IUseCase<GetVehicleByIdInput>
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private IGetVehicleByIdOutputPort _getVehicleByIdOutputPort = outputPort;

        /// <summary>
        /// Sets the output port.
        /// </summary>
        /// <param name="outputPort">The output port to set.</param>
        public void SetOutputPort(IGetVehicleByIdOutputPort outputPort)
        {
            _getVehicleByIdOutputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">The input port to set.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(GetVehicleByIdInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(new VehicleId(input.VehicleId));

            var output = new GetVehicleByIdOutput
            {
                Id = vehicle.Id.Value,
                Model = vehicle.Model,
                Brand = vehicle.Brand,
                ManufacturingDate = vehicle.ManufactureDate.Value,
                IsAvailable = vehicle.IsAvailable
            };

            _getVehicleByIdOutputPort.StandardHandle(output);
        }
    }
}
