using Microsoft.AspNetCore.Routing;

namespace GtMotive.Estimate.Microservice.Api.Common
{
    public interface IFeatureModule
    {
        void AddRoutes(IEndpointRouteBuilder app);
    }
}
