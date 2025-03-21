using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RegisterVehicle.Inputs
{
    /// <summary>
    /// Input message for the RegisterVehicle use case.
    /// </summary>
    public class RegisterVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the vehicle's model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the vehicle's brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the vehicle's manufacture date.
        /// </summary>
        public DateTime ManufactureDate { get; set; }
    }
}
