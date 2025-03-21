using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RegisterVehicle.Outputs
{
    /// <summary>
    /// Output for the RegisterVehicle use case.
    /// </summary>
    public class RegisterVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; set; }
    }
}
