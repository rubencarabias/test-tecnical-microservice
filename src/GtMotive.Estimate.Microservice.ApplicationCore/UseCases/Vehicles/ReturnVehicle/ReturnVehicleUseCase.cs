using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Entities.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Repositories;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Use case to return a vehicle.
    /// </summary>
    /// <param name="vehicleRepository">Repository to manage vehicle data.</param>
    /// <param name="reservationRepository">Repository to manage reservation data.</param>
    /// <param name="outputPort">Output port to handle the response.</param>
    public class ReturnVehicleUseCase(
        IVehicleRepository vehicleRepository,
        IReservationRepository reservationRepository,
        IReturnVehicleOutputPort outputPort)
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        private readonly IReservationRepository _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        private IReturnVehicleOutputPort _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));

        /// <summary>
        /// Set the output port.
        /// </summary>
        /// <param name="outputPort">Output port to handle the response.</param>
        /// <exception cref="ArgumentNullException">Thrown when the output port is null.</exception>
        public void SetOutputPort(IReturnVehicleOutputPort outputPort)
        {
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
        }

        /// <summary>
        /// Execute the use case.
        /// </summary>
        /// <param name="input">The input data for returning the vehicle.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        /// <exception cref="DomainException">Thrown when the reservation is not found, the reservation status is not active, or the vehicle is not available to return.</exception>
        public async Task Execute(ReturnVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var reservation = await _reservationRepository.GetReservationByIdAsync(input.ReservationId)
                ?? throw new DomainException($"Reservation {input.ReservationId} not found");

            if (reservation.Status != ReservationStatus.Active)
            {
                throw new DomainException("The status reservation is not active");
            }

            var vehicleReturned = await _vehicleRepository.ReturnVehicleAsync(
                new VehicleId(reservation.VehicleId));

            if (!vehicleReturned)
            {
                throw new DomainException($"Vehicle {reservation.VehicleId} is not avaible to return");
            }

            reservation.MarkAsReturned(DateTime.UtcNow);

            await _reservationRepository.UpdateAsync(reservation);

            var output = new ReturnVehicleOutput
            {
                IsVehicleReturn = true
            };

            _outputPort.StandardHandle(output);
        }
    }
}
