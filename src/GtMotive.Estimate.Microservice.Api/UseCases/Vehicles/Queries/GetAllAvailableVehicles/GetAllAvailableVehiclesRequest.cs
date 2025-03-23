using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Queries.GetAllAvailableVehicles
{
    /// <summary>
    /// Query to get all available vehicles.
    /// </summary>
    public class GetAllAvailableVehiclesRequest : IRequest<IWebApiPresenter>
    {
    }
}
