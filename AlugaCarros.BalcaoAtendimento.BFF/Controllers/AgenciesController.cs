using AlugaCarros.BalcaoAtendimento.BFF.Dtos.Agencies;
using AlugaCarros.BalcaoAtendimento.BFF.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlugaCarros.BalcaoAtendimento.BFF.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AgenciesController : Controller
{
    private readonly IAgencyServiceApiRepository _agencyServiceApiRepository;

    public AgenciesController(IAgencyServiceApiRepository agencyServiceApiRepository)
    {
        _agencyServiceApiRepository = agencyServiceApiRepository;
    }

    [HttpGet]
    [ProducesResponseType(typeof(AgencyResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status424FailedDependency)]
    public async Task<IActionResult> GetVehiclesByAgency()
    {
        var response = await _agencyServiceApiRepository.GetAgencies();
        if (response.Fail) return StatusCode(StatusCodes.Status424FailedDependency, response.Message);

        return Ok(response.Data.OrderBy(o => o.AgencyName));
    }
}
