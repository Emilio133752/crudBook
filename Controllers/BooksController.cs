using System.Linq.Expressions;
using crudBook.Data;
using crudBook.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudBook.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }
        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks() 
        {
            try 
            {
                var books = await _context.Books.ToListAsync();
                return Ok(books);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }  
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id) 
        {

            try 
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null) return NotFound();
                return book;
            }
             catch(Exception ex)
             {
                return StatusCode(500, ex.Message);
            }

        }

        //Metodo Post

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            try
            {
                if (book == null)
                    return BadRequest("Dados Invalidos");

                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
            }
            catch (Exception ex)
            { 
                return StatusCode(500, ex.Message); 
            }  
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            try
            {
                if (id != book.Id)
                    return BadRequest("ID do livro não corresponde");
                _context.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
