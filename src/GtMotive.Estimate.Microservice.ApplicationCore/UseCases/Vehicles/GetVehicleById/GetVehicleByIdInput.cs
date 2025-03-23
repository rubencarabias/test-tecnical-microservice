using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicleById
{
    /// <summary>
    /// Input for the Get Vehicle by Id use case.
    /// </summary>
    public class GetVehicleByIdInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; set; }
    }
}
