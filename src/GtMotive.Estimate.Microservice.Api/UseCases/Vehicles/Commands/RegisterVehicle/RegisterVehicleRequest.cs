using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.RegisterVehicle
{
    /// <summary>
    /// Command to create a vehicle.
    /// </summary>
    internal sealed record RegisterVehicleRequest : IRequest<IWebApiPresenter>
    {
        [Required]
        public string Model { get; set; }

        [Required]
        public string Brand { get; set; }

        public DateTime ManufacturingDate { get; set; }
    }
}
