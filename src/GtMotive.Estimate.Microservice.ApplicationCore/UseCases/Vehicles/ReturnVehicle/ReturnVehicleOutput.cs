namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle
{
    /// <summary>
    /// Output for the return vehicle use case.
    /// </summary>
    public class ReturnVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets a value indicating whether the vehicle has been returned.
        /// </summary>
        public bool IsVehicleReturn { get; set; }
    }
}
