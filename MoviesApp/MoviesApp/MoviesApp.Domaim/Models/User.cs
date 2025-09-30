using System.Runtime.ExceptionServices;
using MoviesApp.Domaim.Enums;

namespace MoviesApp.Domaim.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenreEnum FavoriteGenre { get; set; }
        public List<Movie>MovieList { get; set; }
    }
}
