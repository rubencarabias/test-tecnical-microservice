using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities.Vehicles
{
    /// <summary>
    /// Represents a vehicle from the rental fleet of the <see cref="Vehicle"/> class.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Vehicle"/> class.
    /// </remarks>
    public class Vehicle(string brand, string model, ManufacturingDate manufactureDate)
    {
        /// <summary>
        /// Gets the vehicle's unique identifier.
        /// </summary>
        public VehicleId Id { get; private set; } = new VehicleId(Guid.NewGuid());

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        public string Model { get; private set; } = model;

        /// <summary>
        /// Gets the brand of the vehicle.
        /// </summary>
        public string Brand { get; private set; } = brand;

        /// <summary>
        /// Gets the vehicle's manufacturing date.
        /// </summary>
        public ManufacturingDate ManufactureDate { get; private set; } = manufactureDate ?? throw new ArgumentNullException(nameof(manufactureDate));

        /// <summary>
        /// Gets a value indicating whether gets value indicating whether the vehicle is available for rent.
        /// </summary>
        public bool IsAvailable { get; private set; } = true;
    }
}
