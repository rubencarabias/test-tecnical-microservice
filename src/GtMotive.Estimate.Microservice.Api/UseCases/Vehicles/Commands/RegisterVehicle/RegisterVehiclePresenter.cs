using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RegisterVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.RegisterVehicle
{
    public class RegisterVehiclePresenter : IRegisterVehicleOutputPort, IWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(RegisterVehicleOutput response)
        {
            ActionResult = new ObjectResult(response);
        }
    }
}
