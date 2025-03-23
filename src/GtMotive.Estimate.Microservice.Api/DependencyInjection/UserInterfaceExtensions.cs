using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.RegisterVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.RentVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Commands.ReturnVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Queries.GetAllAvailableVehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.Queries.GetVehicleById;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetAllAvailableVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.GetVehicleById;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RegisterVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.RentVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ReturnVehicle;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<RegisterVehiclePresenter>();
            services.AddScoped<IRegisterVehicleOutputPort, RegisterVehiclePresenter>();

            services.AddScoped<GetAllAvailableVehiclesPresenter>();
            services.AddScoped<IGetAllAvailableVehiclesOutputPort, GetAllAvailableVehiclesPresenter>();

            services.AddScoped<RentVehiclePresenter>();
            services.AddScoped<IRentVehicleOutputPort, RentVehiclePresenter>();

            services.AddScoped<ReturnVehiclePresenter>();
            services.AddScoped<IReturnVehicleOutputPort, ReturnVehiclePresenter>();

            services.AddScoped<GetVehicleByIdPresenter>();
            services.AddScoped<IGetVehicleByIdOutputPort, GetVehicleByIdPresenter>();

            return services;
        }
    }
}
