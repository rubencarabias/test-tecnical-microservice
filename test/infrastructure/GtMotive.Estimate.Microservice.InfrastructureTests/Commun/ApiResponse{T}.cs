namespace GtMotive.Estimate.Microservice.InfrastructureTests.Commun
{
    /// <summary>
    /// Generic infrastructure test server fixture.
    /// </summary>
    /// <typeparam name="T">The type of the data.</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public T Data { get; set; }
    }
}
