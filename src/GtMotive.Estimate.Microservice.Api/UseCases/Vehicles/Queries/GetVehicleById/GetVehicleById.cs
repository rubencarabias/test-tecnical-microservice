using System.Threading;
using GtMotive.Estimate.Microservice.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Queries.GetVehicleById
{
    public class GetVehicleById : IFeatureModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet(
                "/vehicles/{id}",
                async (string id, ISender mediator, CancellationToken cancellationToken) =>
                {
                    var query = new GetVehicleByIdRequest(id);
                    var presenter = await mediator.Send(query, cancellationToken);

                    return presenter.ActionResult.ToMinimalApiResult();
                })
                .WithName(nameof(GetVehicleById))
                .WithTags("Vehicles")
                .Produces(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status409Conflict);
        }
    }
}
