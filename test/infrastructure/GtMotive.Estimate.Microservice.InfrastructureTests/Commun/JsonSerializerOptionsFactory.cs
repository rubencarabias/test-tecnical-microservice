using System.Text.Json;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Commun
{
    public static class JsonSerializerOptionsFactory
    {
        public static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
}
