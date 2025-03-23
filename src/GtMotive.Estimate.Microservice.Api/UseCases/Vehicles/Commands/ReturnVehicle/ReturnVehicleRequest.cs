using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.ReturnVehicle
{
    internal class ReturnVehicleRequest : IRequest<IWebApiPresenter>
    {
        [Required(ErrorMessage = "Reservationid is required.")]
        public string ReservationId { get; set; }
    }
}
