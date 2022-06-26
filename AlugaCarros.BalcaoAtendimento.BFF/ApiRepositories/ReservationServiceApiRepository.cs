using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Reservations;
using AlugaCarros.BalcaoAtendimento.BFF.Interfaces;
using AlugaCarros.Core.Dtos;
using AlugaCarros.Core.WebApi;
using System.Net;

namespace AlugaCarros.BalcaoAtendimento.BFF.ApiRepositories;

public class ReservationServiceApiRepository : IReservationServiceApiRepository
{
    private readonly HttpClient _httpClient;
    public ReservationServiceApiRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Reservations");
    }

    public async Task<ResultDto<ReservationResponse>> GetReservations(string agencyCode)
    {
        var response = await _httpClient.GetAsync($"api/v1/reservations/agency/{agencyCode}");

        if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NotFound)
            return ResultDto<ReservationResponse>.Failed("Ocorreu um erro ao realizar a busca de reservas");

        var reservationsResponse = await response.Deserialize<ReservationResponse>();

        return ResultDto<ReservationResponse>.Success(reservationsResponse);
    }

    public async Task<ResultDto<ReservationResponseItem>> GetReservationByCode(string reservationCode)
    {
        var response = await _httpClient.GetAsync($"api/v1/reservations/{reservationCode}");

        if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NotFound)
            return ResultDto<ReservationResponseItem>.Failed("Ocorreu um erro ao realizar a busca da reserva");

        var reservationResponse = await response.Deserialize<ReservationResponseItem>();

        return ResultDto<ReservationResponseItem>.Success(reservationResponse);
    }
}