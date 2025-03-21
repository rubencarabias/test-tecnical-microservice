using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle
{
    /// <summary>
    /// Output message for the RentVehicle use case.
    /// </summary>
    public class RentVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets the reservation identifier.
        /// </summary>
        public Guid ReservationId { get; set; }
    }
}
