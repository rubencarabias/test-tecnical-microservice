using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities.Vehicles;

namespace GtMotive.Estimate.Microservice.Domain.Repositories
{
    /// <summary>
    /// Interface for the vehicle repository.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Add a vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddAsync(Vehicle vehicle);

        /// <summary>
        /// Get all vehicles.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IReadOnlyList<Vehicle>> GetAllAvailableVehiclesAsync();

        /// <summary>
        /// Rent a vehicle.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to rent.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation, with a boolean result indicating success or failure.</returns>
        Task<bool> RentVehicleAsync(VehicleId vehicleId);

        /// <summary>
        /// Return a vehicle.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to return.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation, with a boolean result indicating success or failure.</returns>
        Task<bool> ReturnVehicleAsync(VehicleId vehicleId);

        /// <summary>
        /// Get a vehicle by its ID.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle to retrieve.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation, with the vehicle as the result.</returns>
        Task<Vehicle> GetVehicleByIdAsync(VehicleId vehicleId);
    }
}
