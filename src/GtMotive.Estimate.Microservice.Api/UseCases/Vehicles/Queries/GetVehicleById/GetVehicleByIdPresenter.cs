using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicleById;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Queries.GetVehicleById
{
    public class GetVehicleByIdPresenter : IGetVehicleByIdOutputPort, IWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(GetVehicleByIdOutput response)
        {
            ActionResult = new ObjectResult(response);
        }
    }
}
