using System.Threading;
using GtMotive.Estimate.Microservice.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Queries.GetAllAvailableVehicles
{
    public class GetAllAvailableVehicles : IFeatureModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet(
                "/vehicles/available",
                async (ISender mediator, CancellationToken cancellationToken) =>
                {
                    var query = new GetAllAvailableVehiclesRequest();
                    var presenter = await mediator.Send(query, cancellationToken);
                    return Results.StatusCode((int)presenter.ActionResult.GetType().GetProperty("StatusCode").GetValue(presenter.ActionResult));
                })
                .WithName(nameof(GetAllAvailableVehicles))
                .WithTags("Vehicles")
                .Produces(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status409Conflict);
        }
    }
}
