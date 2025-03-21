using System.Collections.ObjectModel;
using GtMotive.Estimate.Microservice.Domain.Entities.Vehicles;

namespace GtMotive.Estimate.Microservice.Domain.Entities.Customer
{
    /// <summary>
    /// Customer entity.
    /// </summary>
    public class Customer(CustomerId id, string name, string lastName)
    {
        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        public CustomerId Id { get; private set; } = id;

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        public string Name { get; } = name;

        /// <summary>
        /// Gets the last name of the customer.
        /// </summary>
        public string LastName { get; private set; } = lastName;

        /// <summary>
        /// Gets the full name of the customer.
        /// </summary>
        public string FullName => $"{Name} {LastName}";

        /// <summary>
        /// Gets the vehicles rented by the customer.
        /// </summary>
        public ReadOnlyCollection<Vehicle> RentVehicles { get; private set; } = new ReadOnlyCollection<Vehicle>([]);
    }
}
