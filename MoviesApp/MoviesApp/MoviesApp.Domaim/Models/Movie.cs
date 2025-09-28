using MoviesApp.Domaim.Enums;

namespace MoviesApp.Domaim.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; } 
        public int Year { get; set; }
        public GenreEnum Genre { get; set; }
        public int Userid { get; set; }
        public User User { get; set; }
    }
}
