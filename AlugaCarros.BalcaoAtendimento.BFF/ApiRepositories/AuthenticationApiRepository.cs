using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Users;
using AlugaCarros.BalcaoAtendimento.BFF.Interfaces;
using AlugaCarros.Core.Dtos;
using AlugaCarros.Core.WebApi;

namespace AlugaCarros.BalcaoAtendimento.BFF.ApiRepositories;
public class AuthenticationApiRepository : IAuthenticationApiRepository
{
    private readonly HttpClient _httpClient;

    public AuthenticationApiRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Authentication");
    }

    public async Task<ResultDto<UserLoginResponse>> Login(UserLogin userLoginRequest)
    {
        var loginContent = userLoginRequest.ToStringContent();

        var response = await _httpClient.PostAsync("/api/v1/users/login", loginContent);

        if (!response.IsSuccessStatusCode) return ResultDto<UserLoginResponse>.Failed("Ocorreu um erro ao realizar Login!");

        var userLoginResponse = await response.Deserialize<UserLoginResponse>();

        return ResultDto<UserLoginResponse>.Success(userLoginResponse);
    }
}

