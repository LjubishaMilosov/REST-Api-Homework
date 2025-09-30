using MoviesApp.DataAccess.Interfaces;
using MoviesApp.Domaim.Enums;
using MoviesApp.Domaim.Models;

namespace MoviesApp.DataAccess.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        public void Add(Movie entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Movie entity)
        {
            throw new NotImplementedException();
        }

        public List<Movie> FilterMovies(int? year, GenreEnum? genre)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
