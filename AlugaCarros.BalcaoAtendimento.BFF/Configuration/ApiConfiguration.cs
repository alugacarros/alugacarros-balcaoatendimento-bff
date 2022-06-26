using AlugaCarros.BalcaoAtendimento.BFF.ApiRepositories;
using AlugaCarros.BalcaoAtendimento.BFF.Interfaces;
using AlugaCarros.Core.ApiConfiguration;
using AlugaCarros.Core.Middlewares;
using AlugaCarros.Core.WebApi;

namespace AlugaCarros.BalcaoAtendimento.BFF.Configuration;
public static class ApiConfiguration
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDefaultApiConfiguration(configuration);
        services.AddAuthentication(configuration);

        services.RegistryDependencies(configuration);

        return services;
    }

    private static IServiceCollection RegistryDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
        services.AddHttpClient<HttpClientAuthorizationDelegatingHandler>("Vehicles", configuration["VehiclesUrl"]);
        services.AddHttpClient<HttpClientAuthorizationDelegatingHandler>("Reservations", configuration["ReservationsUrl"]);
        services.AddHttpClient<HttpClientAuthorizationDelegatingHandler>("Locations", configuration["LocationsUrl"]);
        services.AddHttpClient<HttpClientAuthorizationDelegatingHandler>("Authentication", configuration["AuthenticationUrl"]);

        services.AddTransient<IVehicleServiceApiRepository, VehicleServiceApiRepository>();
        services.AddTransient<IAuthenticationApiRepository, AuthenticationApiRepository>();
        services.AddTransient<IAgencyServiceApiRepository, AgencyServiceApiRepository>();
        services.AddTransient<IReservationServiceApiRepository, ReservationServiceApiRepository>();
        services.AddTransient<ILocationServiceApiRepository, LocationServiceApiRepository>();
        return services;
    }

    public static WebApplication UseAppConfiguration(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.UseMiddleware<ErrorHandlingMiddleware>();
        app.UseMiddleware<LoggingRequestMiddleware>();

        app.UseCors("Total");

        return app;
    }
}