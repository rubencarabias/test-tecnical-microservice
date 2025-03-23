using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.ReturnVehicle
{
    internal class ReturnVehicleHandler(
        ReturnVehicleUseCase useCase,
        ReturnVehiclePresenter presenter)
        : IRequestHandler<ReturnVehicleRequest, IWebApiPresenter>
    {
        private readonly ReturnVehicleUseCase _useCase = useCase;
        private readonly ReturnVehiclePresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(ReturnVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new ReturnVehicleInput
            {
                ReservationId = Guid.Parse(request.ReservationId)
            };

            _useCase.SetOutputPort(_presenter);
            await _useCase.Execute(input);

            return _presenter;
        }
    }
}
