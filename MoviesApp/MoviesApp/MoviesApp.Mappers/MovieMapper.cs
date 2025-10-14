using MoviesApp.Domaim.Models;
using MoviesApp.Dtos;

namespace MoviesApp.Mappers
{
    public static class MovieMapper
    {
        // from domain class to movieDto
        public static MovieDto ToMovieDto(this Movie movie) // extention method
        {
            return new MovieDto
            {
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Genre = movie.Genre
            };
        }

        // from dto to domain class
        public static Movie ToMovie(this AddMovieDto addMovie)
        {
            return new Movie
            {
                Title = addMovie.Title,
                Description = addMovie.Description,
                Year = addMovie.Year,
                Genre = addMovie.Genre
            };
        }
    }
}
