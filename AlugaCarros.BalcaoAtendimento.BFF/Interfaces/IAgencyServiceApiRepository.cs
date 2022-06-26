using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Agencies;
using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Vehicles;
using AlugaCarros.Core.Dtos;

namespace AlugaCarros.BalcaoAtendimento.BFF.Interfaces;
public interface IAgencyServiceApiRepository
{
    Task<ResultDto<AgencyResponse>> GetAgencies();
}