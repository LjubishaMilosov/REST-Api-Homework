using Microsoft.EntityFrameworkCore;
using MoviesApp.DataAccess.Interfaces;
using MoviesApp.Domaim.Enums;
using MoviesApp.Domaim.Models;

namespace MoviesApp.DataAccess.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesDbContext _dbContext;
        public MovieRepository(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Movie entity)
        {
            _dbContext.Movies.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Movie entity)
        {
            _dbContext.Movies.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Movie> FilterMovies(int? year, GenreEnum? genre)
        {
            //if both year and genre are null
            if(year == null && genre == null)  // return all movies OR throw exception that we need at least one filter
            {
                return GetAll();
            }
            // if year is null and gene is not null
            if(year == null && genre != null)
            {
                return _dbContext.Movies
                    .Include(x => x.User)
                    .Where(m => m.Genre == genre)
                    .ToList();
            }
            // if genre is null and year is not null
            if(year != null && genre == null)
            {
                return _dbContext.Movies
                    .Include(x => x.User)
                    .Where(m => m.Year == year)
                    .ToList();
            }
            // if both are not null
            return _dbContext.Movies
                .Include(x => x.User)
                .Where(m => m.Year == year && m.Genre == genre)
                .ToList();
        }

        public List<Movie> GetAll()
        {
            return _dbContext.Movies.Include(x => x.User).ToList();
        }

        public Movie GetById(int id)
        {
            return _dbContext.Movies
                .Include(x => x.User)
                .FirstOrDefault(m => m.Id == id);
        }

        public void Update(Movie entity)
        {
            _dbContext.Movies.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
