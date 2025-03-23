﻿using System;
using System.Text.Json.Serialization;

namespace GtMotive.Estimate.Microservice.Domain.Entities.Vehicles
{
    /// <summary>
    /// Represents the manufacture date of a vehicle.
    /// </summary>
    public class ManufacturingDate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturingDate"/> class.
        /// </summary>
        /// <param name="value">The manufacture date value.</param>
        [JsonConstructor]
        private ManufacturingDate(DateTime value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the manufacture date value.
        /// </summary>
        public DateTime Value { get; private set; }

        /// <summary>
        /// Creates a new <see cref="ManufacturingDate"/> instance if the provided date is valid.
        /// </summary>
        /// <param name="value">The manufacture date value.</param>
        /// <returns>
        /// A new instance of <see cref="ManufacturingDate"/> if valid; otherwise, throws an exception.
        /// </returns>
        public static ManufacturingDate Create(DateTime value)
        {
            if (value > DateTime.UtcNow)
            {
                throw new DomainException("Manufacture date cannot be in the future.");
            }

            if (value <= DateTime.UtcNow.AddYears(-5))
            {
                throw new DomainException("Vehicles older than 5 years are not allowed.");
            }

            return new ManufacturingDate(value);
        }
    }
}
