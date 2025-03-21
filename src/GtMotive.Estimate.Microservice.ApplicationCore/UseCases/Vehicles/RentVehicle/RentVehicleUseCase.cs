using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Entities.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle
{
    /// <summary>
    /// Use case to rent a vehicle.
    /// </summary>
    public class RentVehicleUseCase(IVehicleRepository vehicleRepository, IReservationRepository reservationRepository, IRentVehicleOutputPort outputPort)
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        private readonly IReservationRepository _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        private IRentVehicleOutputPort _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));

        /// <summary>
        /// Set the output port.
        /// </summary>
        /// <param name="outputPort">The output port to set.</param>
        /// <exception cref="ArgumentNullException">Thrown when the output port is null.</exception>
        public void SetOutputPort(IRentVehicleOutputPort outputPort)
        {
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        }

        /// <summary>
        /// Execute the use case.
        /// </summary>
        /// <param name="input">The input data for renting a vehicle.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        /// <exception cref="DomainException">Thrown when the customer already has an active reservation or the vehicle is not available to rent.</exception>
        public async Task Execute(RentVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var activeReservation = await _reservationRepository.GetReservationByCustomerIdAsync(input.CustomerId);

            if (activeReservation != null && activeReservation.Status == ReservationStatus.Active)
            {
                throw new DomainException("The customer already has a rented vehicle.");
            }

            var vehicleRented = await _vehicleRepository.RentVehicleAsync(
                new VehicleId(input.VehicleId));

            if (!vehicleRented)
            {
                throw new DomainException($"Vehicle {input.VehicleId} is not avaible to rent");
            }

            var reservation = new Reservation(input.CustomerId, input.VehicleId);
            await _reservationRepository.AddAsync(reservation);

            var output = new RentVehicleOutput
            {
                ReservationId = reservation.Id
            };

            _outputPort.StandardHandle(output);
        }
    }
}
