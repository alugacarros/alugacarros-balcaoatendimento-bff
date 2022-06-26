using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Reservations;
using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Vehicles;
using AlugaCarros.BalcaoAtendimento.BFF.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlugaCarros.BalcaoAtendimento.BFF.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class ReservationsController : Controller
{
    private readonly IReservationServiceApiRepository _reservationServiceApiRepository;

    public ReservationsController(IReservationServiceApiRepository reservationServiceApiRepository)
    {
        _reservationServiceApiRepository = reservationServiceApiRepository;
    }

    /// <summary>
    /// Get Reservations by Agency Code
    /// </summary>
    /// <param name="agencyCode">The code for the agency that will be searched</param>
    /// <returns></returns>
    [HttpGet("opened")]
    [ProducesResponseType(typeof(ReservationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status424FailedDependency)]
    public async Task<IActionResult> GetOpenedReservations([FromHeader][Required] string agencyCode)
    {
        var response = await _reservationServiceApiRepository.GetReservations(agencyCode);
        if (response.Fail) return StatusCode(StatusCodes.Status424FailedDependency, response.Message);

        var result = new ReservationResponse(
                                                     response.Data
                                                     .Where(w => w.Status == ReservationStatus.Opened)
                                                     .OrderBy(o => o.PickupDate)
                                                     .ToList());

        return Ok(result);
    }

    [HttpGet("")]
    [ProducesResponseType(typeof(ReservationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status424FailedDependency)]
    public async Task<IActionResult> GetReservations([FromHeader][Required] string agencyCode)
    {
        var response = await _reservationServiceApiRepository.GetReservations(agencyCode);
        if (response.Fail) return StatusCode(StatusCodes.Status424FailedDependency, response.Message);

        var result = new ReservationResponse(
                                                     response.Data
                                                     .OrderBy(o => o.PickupDate)
                                                     .ToList());

        return Ok(result);
    }

    /// <summary>
    /// Get Reservation By Code
    /// </summary>
    /// <param name="reservationCode">The code for the Reservation that will be searched</param>
    /// <returns></returns>
    [HttpGet("{reservationCode}")]
    [ProducesResponseType(typeof(ReservationResponseItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status424FailedDependency)]
    public async Task<IActionResult> GetReservation([FromRoute][Required] string reservationCode)
    {
        var response = await _reservationServiceApiRepository.GetReservationByCode(reservationCode);
        if (response.Fail) return StatusCode(StatusCodes.Status424FailedDependency, response.Message);

        return Ok(response.Data);
    }
}
