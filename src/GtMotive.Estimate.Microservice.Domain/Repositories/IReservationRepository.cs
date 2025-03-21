using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates;

namespace GtMotive.Estimate.Microservice.Domain.Repositories
{
    /// <summary>
    /// Interface for the reservation repository.
    /// </summary>
    public interface IReservationRepository
    {
        /// <summary>
        /// Adds a reservation.
        /// </summary>
        /// <param name="reservation">The reservation to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddAsync(Reservation reservation);

        /// <summary>
        /// Gets a reservation by customer ID.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the reservation.</returns>
        Task<Reservation> GetReservationByCustomerIdAsync(Guid customerId);
    }
}
