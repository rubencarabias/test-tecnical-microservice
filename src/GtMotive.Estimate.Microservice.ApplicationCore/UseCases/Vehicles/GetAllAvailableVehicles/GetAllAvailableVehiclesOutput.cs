using GtMotive.Estimate.Microservice.Domain.Entities.Vehicles;
using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAllAvailableVehicles
{
    /// <summary>
    /// Output for the GetAllAvailableVehicles use case.
    /// </summary>
    public class GetAllAvailableVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets the vehicles.
        /// </summary>
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
