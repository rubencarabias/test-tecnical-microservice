namespace GtMotive.Estimate.Microservice.Domain.Aggregates
{
    /// <summary>
    /// Represents the status of a reservation.
    /// </summary>
    public enum ReservationStatus
    {
        /// <summary>
        /// The reservation is active.
        /// </summary>
        Active,

        /// <summary>
        /// The reservation has been returned.
        /// </summary>
        Returned
    }
}
