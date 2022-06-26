using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Locations;
using AlugaCarros.BalcaoAtendimento.BFF.Interfaces;
using AlugaCarros.Core.Dtos;
using AlugaCarros.Core.WebApi;

namespace AlugaCarros.BalcaoAtendimento.BFF.ApiRepositories;

public class LocationServiceApiRepository : ILocationServiceApiRepository
{
    private readonly HttpClient _httpClient;
    public LocationServiceApiRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Locations");
    }

    public async Task<bool> CreateLocation(string reservationCode, string vehiclePlate)
    {
        var content = new { reservationCode, vehiclePlate }.ToStringContent();

        var response = await _httpClient.PostAsync("api/v1/locations", content);
        
        return response.IsSuccessStatusCode;
    }

    public async Task<ResultDto<List<LocationResponse>>> GetLocations(string agencyCode)
    {
        var response = await _httpClient.GetAsync($"api/v1/locations/{agencyCode}");

        if (!response.IsSuccessStatusCode) return ResultDto<List<LocationResponse>>.Failed("Ocorreu um erro ao buscar as locações");

        var locations = await response.Deserialize<List<LocationResponse>>();

        return ResultDto<List<LocationResponse>>.Success(locations);
    }
}
