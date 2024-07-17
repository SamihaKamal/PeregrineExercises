using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRank.Contracts;
using MovieRank.Services;

namespace MovieRank.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRankService _movieRankService;

        public MovieController(IMovieRankService movieRankService)
        {
            _movieRankService = movieRankService;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
            var result = await _movieRankService.GetAllItemsFromDatabase();

            return result;
        }

        [HttpGet]
        [Route("{userId}/{movieName}")]
        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var result = await _movieRankService.GetMovie(userId, movieName);

            return result;
        }

        [HttpGet]
        [Route("user/{userId}/rankedMovies/{movieName}")]
        public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var result = await _movieRankService.GetUsersRankedMoviesByMovieTitle(userId, movieName);

            return result;
        }

        [HttpPost]
        [Route("{userId}")]
        public async Task<IActionResult> addMovie(int userId, [FromBody] MovieRankRequest movieRankRequest)
        {
            await _movieRankService.AddMovie(userId, movieRankRequest);

            return Ok();
        }

        [HttpPatch]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateMovie(int userId, [FromBody] MovieUpdateRequest movieUpdateRequest)
        {
            await _movieRankService.UpdateMovie(userId, movieUpdateRequest);

            return Ok();
        }

        [HttpGet]
        [Route("{movieName}/ranking")]
        public async Task<MovieRankResponse> GetMovieRanking(string movieName)
        {
            var result = await _movieRankService.GetMovieRank(movieName);

            return result;
        }


    }
}
