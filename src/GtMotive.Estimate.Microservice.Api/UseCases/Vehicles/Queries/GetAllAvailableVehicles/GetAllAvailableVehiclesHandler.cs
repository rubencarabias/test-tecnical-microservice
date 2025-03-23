using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAllAvailableVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Queries.GetAllAvailableVehicles
{
    internal class GetAllAvailableVehiclesHandler(GetAllAvailableVehiclesUseCase useCase, GetAllAvailableVehiclesPresenter presenter) : IRequestHandler<GetAllAvailableVehiclesRequest, IWebApiPresenter>
    {
        private readonly GetAllAvailableVehiclesUseCase _useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));
        private readonly GetAllAvailableVehiclesPresenter _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));

        public async Task<IWebApiPresenter> Handle(GetAllAvailableVehiclesRequest request, CancellationToken cancellationToken)
        {
            var input = new GetAllAvailableVehiclesInput();
            _useCase.SetOutputPort(_presenter);
            await _useCase.Execute(input);

            return _presenter;
        }
    }
}
