using System.Threading;
using GtMotive.Estimate.Microservice.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.ReturnVehicle
{
    public class ReturnVehicle : IFeatureModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost(
                "/vehicles/return",
                async (ReturnVehicleRequest command, ISender mediator, CancellationToken cancellationToken) =>
                {
                    var presenter = await mediator.Send(command, cancellationToken);
                    return Results.StatusCode((int)presenter.ActionResult.GetType().GetProperty("StatusCode").GetValue(presenter.ActionResult));
                })
                .WithName(nameof(ReturnVehicle))
                .WithTags("Vehicles")
                .Produces(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status409Conflict);
        }
    }
}
