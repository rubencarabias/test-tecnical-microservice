using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.RegisterVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RegisterVehicle.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<RegisterVehiclePresenter>();
            services.AddScoped<IRegisterVehicleOutputPort, RegisterVehiclePresenter>();

            return services;
        }
    }
}
