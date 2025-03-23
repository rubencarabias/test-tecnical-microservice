using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Queries.GetAllAvailableVehicles
{
    /// <summary>
    /// Query to get all available vehicles.
    /// </summary>
    internal class GetAllAvailableVehiclesRequest : IRequest<IWebApiPresenter>
    {
    }
}
