using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle
{
    /// <summary>
    /// Input message for the RentVehicle use case.
    /// </summary>
    public class ReturnVehicleInput
    {
        /// <summary>
        /// Gets or sets the reservation ID.
        /// </summary>
        public Guid ReservationId { get; set; }
    }
}
