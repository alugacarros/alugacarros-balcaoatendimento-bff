using AlugaCarros.BalcaoAtendimento.BFF.Dtos;
using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Locations;
using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Reservations;
using AlugaCarros.BalcaoAtendimento.BFF.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlugaCarros.BalcaoAtendimento.BFF.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class LocationsController : Controller
{
    private readonly ILocationServiceApiRepository _locationServiceApiRepository;

    public LocationsController(ILocationServiceApiRepository locationServiceApiRepository)
    {
        _locationServiceApiRepository = locationServiceApiRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status424FailedDependency)]
    public async Task<IActionResult> OpenLocation([FromBody][Required] CreateLocationRequest createLocationRequest)
    {
        var success = await _locationServiceApiRepository.CreateLocation(
            createLocationRequest.ReservationCode, createLocationRequest.VehiclePlate);
        if (success) return Ok();

        return StatusCode(StatusCodes.Status424FailedDependency, "Ocorreu um erro ao criar a locação");
    }

    [HttpGet("{agencyCode}")]
    [ProducesResponseType(typeof(List<LocationResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status424FailedDependency)]
    public async Task<IActionResult> GetLocations([FromRoute] string agencyCode)
    {
        var response = await _locationServiceApiRepository.GetLocations(agencyCode);
        if (response.Fail)
            return StatusCode(StatusCodes.Status424FailedDependency, response.Message);

        return Ok(response.Data);

    }
}
