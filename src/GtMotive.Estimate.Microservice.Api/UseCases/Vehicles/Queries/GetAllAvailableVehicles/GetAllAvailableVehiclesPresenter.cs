using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAllAvailableVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Queries.GetAllAvailableVehicles
{
    /// <summary>
    /// Presenter for the Get All Available Vehicles use case.
    /// </summary>
    public class GetAllAvailableVehiclesPresenter : IGetAllAvailableVehiclesOutputPort, IWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(GetAllAvailableVehiclesOutput response)
        {
            ActionResult = new ObjectResult(response);
        }
    }
}
