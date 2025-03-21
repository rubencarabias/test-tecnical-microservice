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
        /// <param name="vehicle">Vehiculo.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddAsync(Vehicle vehicle);
    }
}
