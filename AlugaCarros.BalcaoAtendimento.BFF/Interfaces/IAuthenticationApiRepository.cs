using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Users;
using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Vehicles;
using AlugaCarros.Core.Dtos;

namespace AlugaCarros.BalcaoAtendimento.BFF.Interfaces;

public interface IAuthenticationApiRepository
{
    Task<ResultDto<UserLoginResponse>> Login(UserLogin userLoginRequest);
}