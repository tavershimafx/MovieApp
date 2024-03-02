using MusicApp.Models;

namespace MusicApp.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieSnapshot>> GetMovies(string search);

        IEnumerable<string> MostSearched();

        Task<MovieDetail> MovieDetail(string imdbId);
    }
}