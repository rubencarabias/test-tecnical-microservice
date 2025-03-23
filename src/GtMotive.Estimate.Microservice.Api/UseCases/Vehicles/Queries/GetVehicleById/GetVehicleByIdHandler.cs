using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Queries.GetVehicleById;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicleById;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.GetVehicleById
{
    public class GetVehicleByIdHandler(GetVehicleByIdUseCase useCase, GetVehicleByIdPresenter presenter)
        : IRequestHandler<GetVehicleByIdRequest, IWebApiPresenter>
    {
        private readonly GetVehicleByIdUseCase _useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));
        private readonly GetVehicleByIdPresenter _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));

        public async Task<IWebApiPresenter> Handle(GetVehicleByIdRequest request, CancellationToken cancellationToken)
        {
            var input = new GetVehicleByIdInput
            {
                VehicleId = Guid.Parse(request?.VehicleId)
            };

            _useCase.SetOutputPort(_presenter);
            await _useCase.Execute(input);

            return _presenter;
        }
    }
}
