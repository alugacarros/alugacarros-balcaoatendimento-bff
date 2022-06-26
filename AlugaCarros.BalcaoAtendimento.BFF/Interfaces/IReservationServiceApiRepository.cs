using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Reservations;
using AlugaCarros.Core.Dtos;

namespace AlugaCarros.BalcaoAtendimento.BFF.Interfaces;

public interface IReservationServiceApiRepository
{
    Task<ResultDto<ReservationResponse>> GetReservations(string agencyCode);
    Task<ResultDto<ReservationResponseItem>> GetReservationByCode(string reservationCode);
}