using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Entities.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore.UseCasesTests
{
    public class ReturnVehicleUseCaseTests
    {
        private readonly Mock<IVehicleRepository> _vehicleRepositoryMock;
        private readonly Mock<IReservationRepository> _reservationRepositoryMock;
        private readonly Mock<IReturnVehicleOutputPort> _outputPortMock;
        private readonly ReturnVehicleUseCase _useCase;

        public ReturnVehicleUseCaseTests()
        {
            _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            _reservationRepositoryMock = new Mock<IReservationRepository>();
            _outputPortMock = new Mock<IReturnVehicleOutputPort>();

            _useCase = new ReturnVehicleUseCase(
                _vehicleRepositoryMock.Object,
                _reservationRepositoryMock.Object,
                _outputPortMock.Object);

            _useCase.SetOutputPort(_outputPortMock.Object);
        }

        [Fact]
        public async Task ExecuteShouldReturnVehicleWhenInputIsValid()
        {
            var reservationId = Guid.NewGuid();

            _reservationRepositoryMock
            .Setup(repo => repo.GetReservationByIdAsync(reservationId))
            .ReturnsAsync(new Reservation(Guid.NewGuid(), reservationId));

            _vehicleRepositoryMock
            .Setup(repo => repo.ReturnVehicleAsync(It.IsAny<VehicleId>()))
            .ReturnsAsync(true);

            var input = new ReturnVehicleInput
            {
                ReservationId = reservationId
            };

            await _useCase.Execute(input);

            _reservationRepositoryMock.Verify(repo => repo.GetReservationByIdAsync(It.IsAny<Guid>()), Times.Once);

            _vehicleRepositoryMock.Verify(repo => repo.ReturnVehicleAsync(It.IsAny<VehicleId>()), Times.Once);

            _reservationRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Reservation>()), Times.Once);

            _outputPortMock.Verify(port => port.StandardHandle(It.IsAny<ReturnVehicleOutput>()), Times.Once);
        }

        [Fact]
        public async Task ExecuteShouldThrowDomainExceptionWheReservationIdIsInvalid()
        {
            var input = new ReturnVehicleInput
            {
                ReservationId = Guid.NewGuid()
            };

            _reservationRepositoryMock
            .Setup(repo => repo.GetReservationByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Reservation)null);

            await Assert.ThrowsAsync<DomainException>(() => _useCase.Execute(input));

            _reservationRepositoryMock.Verify(repo => repo.GetReservationByIdAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}
