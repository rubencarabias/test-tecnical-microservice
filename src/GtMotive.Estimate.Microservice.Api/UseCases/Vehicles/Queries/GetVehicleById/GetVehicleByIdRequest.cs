using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Queries.GetVehicleById
{
    /// <summary>
    /// Query to get a vehicle by its identifier.
    /// </summary>
    public class GetVehicleByIdRequest(string vehicleId) : IRequest<IWebApiPresenter>
    {
        [Required(ErrorMessage = "VehicleId is required.")]
        public string VehicleId { get; set; } = vehicleId;
    }
}
