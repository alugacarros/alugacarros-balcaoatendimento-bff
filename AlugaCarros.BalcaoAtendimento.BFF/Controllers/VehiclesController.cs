using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Vehicles;
using AlugaCarros.BalcaoAtendimento.BFF.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlugaCarros.BalcaoAtendimento.BFF.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class VehiclesController : Controller
{
    private readonly IVehicleServiceApiRepository _vehicleServiceApiRepository;

    public VehiclesController(IVehicleServiceApiRepository vehicleServiceApiRepository)
    {
        _vehicleServiceApiRepository = vehicleServiceApiRepository;
    }

    /// <summary>
    /// Get vehicles by Agency Code
    /// </summary>
    /// <param name="agencyCode">The code for the agency that will be searched</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<VehicleByAgencyResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status424FailedDependency)]
    public async Task<IActionResult> GetVehiclesByAgency([FromHeader][Required] string agencyCode)
    {
        var response = await _vehicleServiceApiRepository.VehiclesByAgency(agencyCode);
        if (response.Fail) return StatusCode(StatusCodes.Status424FailedDependency, response.Message);

        return Ok(response.Data.Select(s => new VehicleByAgencyResult(s)));
    }
}
