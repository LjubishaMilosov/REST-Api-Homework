using MoviesApp.DataAccess.Interfaces;
using MoviesApp.Domaim.Enums;
using MoviesApp.Domaim.Models;
using MoviesApp.Dtos;
using MoviesApp.Mappers;
using MoviesApp.Services.Interfaces;


namespace MoviesApp.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            this._movieRepository = movieRepository;
        }

        public void AddMovie(AddMovieDto addMovieDto, int userId)
        {
            if (addMovieDto == null)
            {
                throw new ArgumentNullException("Movie cannot be null");
            }
            if (string.IsNullOrEmpty(addMovieDto.Title))
            {
                throw new NullReferenceException("Title is a required field");
            }
            if (!string.IsNullOrEmpty(addMovieDto.Description) && addMovieDto.Description.Length > 250)
            {
                throw new Exception("Description cannot be longer than 250 chars");
            }
            var enumValues = Enum.GetValues(typeof(GenreEnum))
                .Cast<GenreEnum>()
                .ToList();
            if (!enumValues.Contains(addMovieDto.Genre))
            {
                throw new Exception("Invalid genre value");
            }
            if (addMovieDto.Year < 0 || addMovieDto.Year > DateTime.Now.Year)
            {
                throw new Exception("Invalid year value");
            }

            Movie newMovie = addMovieDto.ToMovie();
            newMovie.Userid = userId;
            _movieRepository.Add(newMovie); // call the repo with the newly created movie domain model
        }

        public void DeleteMovie(int id)
        {
            // get movie by id and validation
            var movieDb = _movieRepository.GetById(id);
            if (movieDb == null)
            {
                throw new NullReferenceException($"Movie with id {id} does not exist");
            }
            _movieRepository.Delete(movieDb);

        }

        public List<MovieDto> FilterMovies(int? year, GenreEnum? genre)
        {
            // validate if the value for genre is valid
            var enumValues = Enum.GetValues(typeof(GenreEnum))
                  .Cast<GenreEnum>()
                  .ToList();
            if (!enumValues.Contains(genre.Value))
            {
                throw new Exception("Invalid genre value");
            }
            if (year.HasValue && (year < 0 || year > DateTime.Now.Year))
            {
                throw new Exception("Invalid year value");
            }

            return _movieRepository
                .FilterMovies(year, genre)
                .Select(x => x.ToMovieDto())
                .ToList();
        }
        public List<MovieDto> GetAllMovies(int userId)
        {
            return _movieRepository
                .GetAll()
                .Where(m => m.Userid == userId)
                .Select(x => x.ToMovieDto())
                .ToList();
        }

        public MovieDto GetMovieById(int id)
        {
            Movie movieDb = _movieRepository.GetById(id);

            if (movieDb == null)
            {
                throw new NullReferenceException($"Movie with id {id} does not exist");
            }

            return movieDb.ToMovieDto();
        }

        public void UpdateMovie(UpdateMovieDto updateMovieDto)
        {
            //validations
            if(updateMovieDto == null)
            {
                throw new NullReferenceException("Movie cannot be null");
            }
            // find the movie and validate that the movie exist
            var movieDb = _movieRepository.GetById(updateMovieDto.Id);
            if(movieDb == null)
            {
                throw new NullReferenceException($"Movie with id {updateMovieDto.Id} does not exist");
            }
            if (string.IsNullOrEmpty(updateMovieDto.Title))
            {
                throw new NullReferenceException("Title is a required field");
            }
            if (!string.IsNullOrEmpty(updateMovieDto.Description) && updateMovieDto.Description.Length > 250)
            {
                throw new Exception("Description cannot be longer than 250 chars");
            }
            var enumValues = Enum.GetValues(typeof(GenreEnum))
                .Cast<GenreEnum>()
                .ToList();
            if (!enumValues.Contains(updateMovieDto.Genre))
            {
                throw new Exception("Invalid genre value");
            }
            if (updateMovieDto.Year < 0 || updateMovieDto.Year > DateTime.Now.Year)
            {
                throw new Exception("Invalid year value");
            }
            // map the dto to the domain model
            movieDb.Title = updateMovieDto.Title;
            movieDb.Description = updateMovieDto.Description;
            movieDb.Year = updateMovieDto.Year;
            movieDb.Genre = updateMovieDto.Genre;
            _movieRepository.Update(movieDb);

        }
    }
}
