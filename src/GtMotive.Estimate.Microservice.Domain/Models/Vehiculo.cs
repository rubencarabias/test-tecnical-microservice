using System;

namespace GtMotive.Estimate.Microservice.Domain.Models
{
    /// <summary>
    /// Represents a vehicle from the rental fleet.
    /// </summary>
    public class Vehiculo
    {
        /// <summary>
        /// Gets or sets the vehicle's unique identifier.
        /// </summary>
        public string Id { get; protected set; } = default!;

        /// <summary>
        /// Gets or sets the vehicle name or model.
        /// </summary>
        public string Name { get; protected set; } = default!;

        /// <summary>
        /// Gets or sets the vehicle's manufacturing date.
        /// </summary>
        public DateTime ManufacturingDate { get; protected set; } = default!;
    }
}
