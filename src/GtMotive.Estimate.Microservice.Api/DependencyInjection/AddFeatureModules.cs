using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GtMotive.Estimate.Microservice.Api.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class AddFeatureModules
    {
        public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
        {
            var serviceDescriptors = assembly?
                .DefinedTypes
                .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                        type.IsAssignableTo(typeof(IFeatureModule)))
                .Select(type => ServiceDescriptor.Transient(typeof(IFeatureModule), type))
                .ToArray();

            services.TryAddEnumerable(serviceDescriptors);

            return services;
        }

        public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder routeGroupBuilder = null)
        {
            var endpoints = app?.Services.GetRequiredService<IEnumerable<IFeatureModule>>();
            if (endpoints is null)
            {
                return app;
            }

            IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

            foreach (var endpoint in endpoints)
            {
                endpoint.AddRoutes(builder);
            }

            return app;
        }
    }
}
