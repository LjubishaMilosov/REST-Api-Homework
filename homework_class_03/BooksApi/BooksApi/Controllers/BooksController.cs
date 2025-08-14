using BooksApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            try
            {
                return Ok(StaticDb.Books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{index}")]
        public ActionResult<Book> GetBookByIndex(int index)
        {
            try
            {
                if (index < 0)
                {
                    return BadRequest("The index cannot be negative");
                }

                if (index >= StaticDb.Books.Count)
                {
                    return NotFound($"There is no resouce at index {index}");
                }

                return Ok(StaticDb.Books[index]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("search")]
        public ActionResult<List<Book>> SearchBooks(string? author, string? title)
        {
            try
            {
                if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
                {
                    return BadRequest("You need to send at least one filter parameter");
                }
                if (string.IsNullOrEmpty(title))
                {
                    List<Book> booksFilteredByAuthor = StaticDb.Books
                        .Where(b => b.Author.ToLower().Contains(author.ToLower()))
                        .ToList();
                    if (booksFilteredByAuthor.Count == 0)
                    {
                        return NotFound($"No books found by author: {author}");
                    }
                    return Ok(booksFilteredByAuthor);
                }
                if (string.IsNullOrEmpty(author))
                {
                    List<Book> booksFilteredByTitle = StaticDb.Books
                        .Where(b => b.Title.ToLower().Contains(title.ToLower()))
                        .ToList();
                    if (booksFilteredByTitle.Count == 0)
                    {
                        return NotFound($"No books found with title: {title}");
                    }
                    return Ok(booksFilteredByTitle);
                }
                List<Book> filteredBooks = StaticDb.Books
                    .Where(b => b.Author.ToLower().Contains(author.ToLower()) &&
                                b.Title.ToLower().Contains(title.ToLower()))
                    .ToList();
                if (filteredBooks.Count == 0)
                {
                    return NotFound($"No books found by author: {author} with title: {title}");
                }
                return Ok(filteredBooks);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] Book newBook)
        {
            try
            {
                if (newBook == null)
                {
                    return BadRequest("Book cannot be null");
                }

                if (string.IsNullOrEmpty(newBook.Author))
                {
                    return BadRequest("Author is required");
                }

                if (string.IsNullOrEmpty(newBook.Title))
                {
                    return BadRequest("Title is required");
                }

                if (StaticDb.Books.Any(b =>
                    b.Author.Equals(newBook.Author, StringComparison.OrdinalIgnoreCase) &&
                    b.Title.Equals(newBook.Title, StringComparison.OrdinalIgnoreCase)))
                {
                    return BadRequest("Book already exists");
                }

                StaticDb.Books.Add(newBook);

                return StatusCode(StatusCodes.Status201Created, "Book created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}