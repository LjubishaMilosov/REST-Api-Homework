using MoviesApp.Domaim.Enums;
using MoviesApp.Domaim.Models;

namespace MoviesApp.DataAccess.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        List<Movie> FilterMovies(int? year, GenreEnum? genre);
    }
}
