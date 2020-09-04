using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.API.Models;
using Restaurants.API.Services.GoogleAPIServices.Models;
using Restaurants.API.Services.RestaurantsServices;

namespace Restaurants.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CoresController : ControllerBase
    {
        private readonly IRestaurantsServices _restaurantsService;

        public CoresController(IRestaurantsServices restaurantsService) 
        {
            _restaurantsService = restaurantsService;
        }

        //v1/cores/findrestaurants
        [HttpPost("findrestaurants", Name = "find Restaurants")]
        public IActionResult FindRestaurants([FromBody]LocationModels locationModels)
        {
            var data = _restaurantsService.FindRestaurant(locationModels);
            return Ok(data);
        }

        [HttpGet("test", Name = "test")]
        public IActionResult FindRestaurants()
        {
            return Ok("test na ja");
        }
    }
}