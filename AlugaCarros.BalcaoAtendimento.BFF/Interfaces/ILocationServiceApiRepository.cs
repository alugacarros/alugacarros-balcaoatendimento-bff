using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Locations;
using AlugaCarros.Core.Dtos;

namespace AlugaCarros.BalcaoAtendimento.BFF.Interfaces;

public interface ILocationServiceApiRepository
{
    Task<bool> CreateLocation(string reservationCode, string vehiclePlate);
    Task<ResultDto<List<LocationResponse>>> GetLocations(string agencyCode);
}