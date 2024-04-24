namespace HEROESAPI.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using HEROESAPI.Data; // Reference for the DataAccess class
    using HEROESAPI.Models; // Reference for Hero class 

    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly DataAccess _dataAccess;

        public HeroesController(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet("{id}")] // Route for GET requests with an ID parameter
        public async Task<IActionResult> GetHeroNameById(int id)
        {
            var hero = await _dataAccess.GetHeroNameById(id);

            if (hero == null)
            {
                return NotFound(); // Return 404 Not Found if no hero found
            }

            return Ok(hero);  // Return 200 OK with the hero data in JSON format
        }

        [HttpGet] // Route for GET requests (base route from the controller will apply)
        public async Task<IActionResult> GetAllHeroes()
        {
            var heroes = await _dataAccess.GetAllHeroes();

            return Ok(heroes); // Return 200 OK with heroes data in JSON format
        }


    }
}
