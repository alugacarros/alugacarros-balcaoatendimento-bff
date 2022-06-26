using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Vehicles;
using AlugaCarros.Core.Dtos;

namespace AlugaCarros.BalcaoAtendimento.BFF.Interfaces;
public interface IVehicleServiceApiRepository
{
    Task<ResultDto<VehiclesByAgencyResponse>> VehiclesByAgency(string agencyCode);
}