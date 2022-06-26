using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Vehicles;
using AlugaCarros.BalcaoAtendimento.BFF.Interfaces;
using AlugaCarros.Core.Dtos;
using AlugaCarros.Core.WebApi;
using System.Net;

namespace AlugaCarros.BalcaoAtendimento.BFF.ApiRepositories;
public class VehicleServiceApiRepository : IVehicleServiceApiRepository
{
    private readonly HttpClient _httpClient;

    public VehicleServiceApiRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Vehicles");
    }

    public async Task<ResultDto<VehiclesByAgencyResponse>> VehiclesByAgency(string agencyCode)
    {
        var response = await _httpClient.GetAsync($"api/v1/vehicles/agency/{agencyCode}");

        if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NotFound) 
            return ResultDto<VehiclesByAgencyResponse>.Failed("Ocorreu um erro ao realizar a busca de veículos");

        var vehicleByAgencyResponse = await response.Deserialize<VehiclesByAgencyResponse>();

        return ResultDto<VehiclesByAgencyResponse>.Success(vehicleByAgencyResponse);
    }
}

