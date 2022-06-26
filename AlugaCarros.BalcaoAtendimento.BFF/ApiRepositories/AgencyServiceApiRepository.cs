using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Agencies;
using AlugaCarros.BalcaoAtendimento.BFF.Interfaces;
using AlugaCarros.Core.Dtos;
using AlugaCarros.Core.WebApi;
using System.Net;

namespace AlugaCarros.BalcaoAtendimento.BFF.ApiRepositories;
public class AgencyServiceApiRepository : IAgencyServiceApiRepository
{
    private readonly HttpClient _httpClient;
    public AgencyServiceApiRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Vehicles");
    }

    public async Task<ResultDto<AgencyResponse>> GetAgencies()
    {       
        var response = await _httpClient.GetAsync($"api/v1/agencies");

        if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NotFound)
            return ResultDto<AgencyResponse>.Failed("Ocorreu um erro ao realizar a busca de agências");

        var agenciesResponse = await response.Deserialize<AgencyResponse>();

        return ResultDto<AgencyResponse>.Success(agenciesResponse);
    }
}