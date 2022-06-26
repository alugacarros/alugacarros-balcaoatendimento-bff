using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Users;
using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Vehicles;
using AlugaCarros.BalcaoAtendimento.BFF.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlugaCarros.BalcaoAtendimento.BFF.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : Controller
{
    private readonly IAuthenticationApiRepository _authenticationApiRepository;

    public UsersController(IAuthenticationApiRepository authenticationApiRepository)
    {
        _authenticationApiRepository = authenticationApiRepository;
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(UserLoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status424FailedDependency)]
    public async Task<IActionResult> Login(UserLogin userLogin)
    {
        var response = await _authenticationApiRepository.Login(userLogin);

        if (response.Fail) return StatusCode(StatusCodes.Status424FailedDependency, response.Message);

        return Ok(response.Data);
    }
}


