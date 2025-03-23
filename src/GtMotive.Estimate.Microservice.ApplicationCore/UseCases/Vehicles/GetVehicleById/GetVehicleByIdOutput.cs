using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicleById
{
    /// <summary>
    /// Output for the Get Get Vehicle By Id use case.
    /// </summary>
    public class GetVehicleByIdOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets the vehicle.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the vehicle model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the vehicle brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the vehicle manufacture date.
        /// </summary>
        public DateTime ManufacturingDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets a value indicating availability.
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}
