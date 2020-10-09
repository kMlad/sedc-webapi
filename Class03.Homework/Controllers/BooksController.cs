using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Class03.Homework.Models;

namespace Class03.Homework.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public  IActionResult Get()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDb.Books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            try
            {
                if (id < 0 || id > StaticDb.Books.Count)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Please enter a valid id!");
                }
                return StatusCode(StatusCodes.Status200OK, StaticDb.Books[id]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error!");
            }
            
        }

        [HttpGet("book")]
        public ActionResult<Book> GetBook([FromQuery] Book book)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, StaticDb.Books
                                                                   .Where(x => x.Author == book.Author)
                                                                   .FirstOrDefault(_ => _.Title == book.Title));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, something went wrong!");
            }
        }

        [HttpGet("header")]
        public ActionResult<string> GetHeader([FromHeader(Name = "Content-Type")] string type)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, type);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, something went wrong!");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, something went wrong!");
            }
        }

        [HttpPost("get-title")]
        public ActionResult<List<string>> PostBooksGetTitles([FromBody] List<Book> books)
        {
            try
            {
                List<string> bookTitles = new List<string>();
                foreach (Book book in books)
                {
                    bookTitles.Add(book.Title);
                }
                return StatusCode(StatusCodes.Status200OK, bookTitles);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, something went wrong!");
            }

        }
    }
}
