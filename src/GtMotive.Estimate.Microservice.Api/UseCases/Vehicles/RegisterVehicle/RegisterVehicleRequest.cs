using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// Command to create a vehicle.
    /// </summary>
    public sealed record RegisterVehicleRequest : IRequest<IWebApiPresenter>
    {
        [Required]
        public string Model { get; set; }

        [Required]
        public string Brand { get; set; }

        public DateTime ManufacturingDate { get; set; }
    }
}
