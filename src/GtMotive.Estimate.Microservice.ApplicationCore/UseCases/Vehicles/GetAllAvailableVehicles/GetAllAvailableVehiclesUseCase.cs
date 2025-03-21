using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAllAvailableVehicles
{
    /// <summary>
    /// Use case to get all available vehicles.
    /// </summary>
    public class GetAllAvailableVehiclesUseCase(
        IVehicleRepository vehicleRepository,
        IGetAllAvailableVehiclesOutputPort outputPort) : IUseCase<GetAllAvailableVehiclesInput>
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private IGetAllAvailableVehiclesOutputPort _getAllAvailableVehiclesOutputPort = outputPort;

        /// <summary>
        /// Sets the output port.
        /// </summary>
        /// <param name="outputPort">The output port to set.</param>
        public void SetOutputPort(IGetAllAvailableVehiclesOutputPort outputPort)
        {
            _getAllAvailableVehiclesOutputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        }

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">The input port to set.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Execute(GetAllAvailableVehiclesInput input)
        {
            var vehicles = await _vehicleRepository.GetAllAvailableVehiclesAsync();

            var output = new GetAllAvailableVehiclesOutput
            {
                Vehicles = vehicles
            };

            _getAllAvailableVehiclesOutputPort.StandardHandle(output);
        }
    }
}
