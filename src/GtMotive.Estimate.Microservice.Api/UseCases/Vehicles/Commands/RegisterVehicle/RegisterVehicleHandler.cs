using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RegisterVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RegisterVehicle.Inputs;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.RegisterVehicle
{
    public class RegisterVehicleHandler(RegisterVehicleUseCase useCase, RegisterVehiclePresenter presenter) : IRequestHandler<RegisterVehicleRequest, IWebApiPresenter>
    {
        private readonly RegisterVehicleUseCase _useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));
        private readonly RegisterVehiclePresenter _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));

        public async Task<IWebApiPresenter> Handle(RegisterVehicleRequest request, CancellationToken cancellationToken)
        {
            var input = new RegisterVehicleInput
            {
                Model = request?.Model,
                Brand = request?.Brand,
                ManufactureDate = request!.ManufacturingDate
            };

            _useCase.SetOutputPort(_presenter);
            await _useCase.Execute(input);

            return _presenter;
        }
    }
}
