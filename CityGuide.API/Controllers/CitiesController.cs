using CityGuide.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CityGuide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesOperations _citiesOperations;

        public CitiesController(ICitiesOperations citiesOperations)
        {
            _citiesOperations = citiesOperations;
        }

        [HttpGet("")]
        public IActionResult GetCities()
        {
            try
            {
                var cities = _citiesOperations.GetCities();

                return Ok(cities);
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
