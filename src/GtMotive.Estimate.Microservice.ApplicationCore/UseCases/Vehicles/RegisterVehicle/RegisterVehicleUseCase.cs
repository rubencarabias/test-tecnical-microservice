using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RegisterVehicle.Inputs;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RegisterVehicle.Outputs;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RegisterVehicle.Ports;
using GtMotive.Estimate.Microservice.Domain.Entities.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RegisterVehicle
{
    /// <summary>
    /// Use case to register a vehicle.
    /// </summary>
    public class RegisterVehicleUseCase(IVehicleRepository vehicleRepository) : IUseCase<RegisterVehicleInput>
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        private IRegisterVehicleOutputPort _registerVehicleOutputPort;

        /// <summary>
        /// Sets the output port.
        /// </summary>
        /// <param name="outputPort">The output port to set.</param>
        public void SetOutputPort(IRegisterVehicleOutputPort outputPort)
        {
            _registerVehicleOutputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">The input port to set.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(RegisterVehicleInput input)
        {
            var vehicle = new Vehicle(input?.Brand, input?.Model, ManufacturingDate.Create(input!.ManufactureDate));

            await _vehicleRepository.AddAsync(vehicle);

            var output = new RegisterVehicleOutput
            {
                VehicleId = vehicle.Id.Value,
            };

            _registerVehicleOutputPort.StandardHandle(output);
        }
    }
}
