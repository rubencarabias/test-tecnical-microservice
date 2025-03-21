using System;

namespace GtMotive.Estimate.Microservice.Domain.Aggregates
{
    /// <summary>
    /// Represents a reservation.
    /// </summary>
    public class Reservation(Guid customerId, Guid vehicleId)
    {
        /// <summary>
        /// Gets the reservation identifier.
        /// </summary>
        public Guid Id { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// Gets the client identifier.
        /// </summary>
        public Guid CustomerId { get; private set; } = customerId;

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; private set; } = vehicleId;

        /// <summary>
        /// Gets the reservation status.
        /// </summary>
        public ReservationStatus Status { get; private set; } = ReservationStatus.Active;

        /// <summary>
        /// Gets the date and time when the reservation was made.
        /// </summary>
        public DateTime ReservedAt { get; private set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets the date and time when the vehicle was returned.
        /// </summary>
        public DateTime? ReturnedAt { get; private set; } = default!;

        /// <summary>
        /// Initializes a new instance of the <see cref="Reservation"/> class.
        /// </summary>
        /// <param name="returnedAt">The date and time when the vehicle was returned.</param>
        public void MarkAsReturned(DateTime returnedAt)
        {
            Status = ReservationStatus.Returned;
            ReturnedAt = returnedAt;
        }
    }
}
