using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Aggregates;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    /// <summary>
    /// Repository to manage reservations in a MongoDB database.
    /// </summary>
    public class ReservationMongoDbRepository(MongoService mongoService) : IReservationRepository
    {
        private readonly IMongoCollection<Reservation> _reservations = mongoService.GetCollection<Reservation>("Reservations");

        public async Task AddAsync(Reservation reservation)
        {
            await _reservations.InsertOneAsync(reservation);
        }

        public async Task<Reservation> GetReservationByCustomerIdAsync(Guid customerId)
        {
            var filter = Builders<Reservation>.Filter.Eq(r => r.CustomerId, customerId) &
                         Builders<Reservation>.Filter.Eq(r => r.Status, ReservationStatus.Active);

            return await _reservations.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(Guid reservationId)
        {
            var filter = Builders<Reservation>.Filter.Eq(r => r.Id, reservationId);
            return await _reservations.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            ArgumentNullException.ThrowIfNull(reservation);

            var filter = Builders<Reservation>.Filter.Eq(r => r.Id, reservation.Id);

            var update = Builders<Reservation>.Update
                .Set(r => r.Status, reservation.Status)
                .Set(r => r.ReturnedAt, reservation.ReturnedAt);

            await _reservations.UpdateOneAsync(filter, update);
        }
    }
}
