using System.Threading;
using GtMotive.Estimate.Microservice.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.RegisterVehicle
{
    public class RegisterVehicle : IFeatureModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost(
                "/vehicles",
                async (RegisterVehicleRequest command, ISender mediator, CancellationToken cancellationToken) =>
                {
                    var presenter = await mediator.Send(command, cancellationToken);
                    return Results.StatusCode((int)presenter.ActionResult.GetType().GetProperty("StatusCode").GetValue(presenter.ActionResult));
                })
                .WithName(nameof(RegisterVehicle))
                .WithTags("Vehicles")
                .Produces(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status409Conflict);
        }
    }
}
