using BooksApi.Models;

namespace BooksApi
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>
        {
            new Book { Author = "Author1", Title = "Title1" },
            new Book { Author = "Author2", Title = "Title2" },
            new Book { Author = "Author3", Title = "Title3" }
        };
    }
}
