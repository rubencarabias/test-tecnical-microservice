using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.RentVehicle
{
    /// <summary>
    /// Command to rent a vehicle.
    /// </summary>
    public class RentVehicleRequest : IRequest<IWebApiPresenter>
    {
        [Required(ErrorMessage = "VehicleId is required.")]
        public string VehicleId { get; set; }

        [Required(ErrorMessage = "CustomerId is required.")]
        public string CustomerId { get; set; }
    }
}
