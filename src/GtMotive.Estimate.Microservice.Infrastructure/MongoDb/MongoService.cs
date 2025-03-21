using System;
using GtMotive.Estimate.Microservice.Domain.Entities.Vehicles;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoService(IOptions<MongoDbSettings> options)
    {
        private readonly string _databaseName = options.Value.MongoDbDatabaseName;

        public MongoClient MongoClient { get; } = new MongoClient(options.Value.ConnectionString);

        public static void RegisterBsonClasses()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Vehicle)))
            {
                BsonClassMap.RegisterClassMap<Vehicle>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdProperty(v => v.Id);
                    cm.MapProperty(v => v.Model).SetIsRequired(true);
                    cm.MapProperty(v => v.ManufactureDate).SetIsRequired(true);
                    cm.MapProperty(v => v.IsAvailable).SetDefaultValue(true);
                });
            }
        }

        public IMongoDatabase GetDatabase()
        {
            return string.IsNullOrEmpty(_databaseName)
                ? throw new ArgumentException("Database name cannot be null or empty.", _databaseName)
                : MongoClient.GetDatabase(_databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return string.IsNullOrEmpty(collectionName)
                ? throw new ArgumentException("Collection name cannot be null or empty.", nameof(collectionName))
                : GetDatabase().GetCollection<T>(collectionName);
        }
    }
}
