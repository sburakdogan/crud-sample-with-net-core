using CityGuide.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CityGuide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownsController : ControllerBase
    {
        private readonly ITownsOperations _townsOperations;

        public TownsController(ITownsOperations townsOperations)
        {
            _townsOperations = townsOperations;
        }

        [HttpGet("")]
        public IActionResult GetTownsByCityId([FromQuery] int cityId)
        {
            try
            {
                var towns = _townsOperations.GetTownsByCityId(cityId);

                return Ok(towns);
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
