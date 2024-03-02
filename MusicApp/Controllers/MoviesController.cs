using Microsoft.AspNetCore.Mvc;
using MusicApp.Services;

namespace MusicApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string q)
        {
            var result = await _movieService.GetMovies(q);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string imdbId)
        {
            var result = await _movieService.MovieDetail(imdbId);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult MostSearched()
        {
            return Ok(_movieService.MostSearched());
        }
    }
}