using System.Threading;
using GtMotive.Estimate.Microservice.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.RentVehicle
{
    public class RentVehicle : IFeatureModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost(
                "/vehicles/rent",
                async ([FromBody] RentVehicleRequest command, ISender mediator, CancellationToken cancellationToken) =>
                {
                    var presenter = await mediator.Send(command, cancellationToken);

                    return presenter.ActionResult.ToMinimalApiResult();
                })
                .WithName(nameof(RentVehicle))
                .WithTags("Vehicles")
                .Produces(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status409Conflict);
        }
    }
}
