using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities.Customer
{
    /// <summary>
    /// Customer identifier.
    /// </summary>
    /// <param name="Value">The unique identifier for the customer.</param>
    public record CustomerId(Guid Value);
}
