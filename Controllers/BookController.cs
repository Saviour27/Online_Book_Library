using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Data.Services;
using MyLibrary.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;


namespace MyLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices _service;

        public BookController(IBookServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allBooks = await _service.GetAll();
            return View(allBooks);
        }

        public async Task<IActionResult> ManageBooksAsync()
        {
            var manage = await _service.GetAll();
            return View(manage);
        }
 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Description,Author,GenreId,Publisher,Language,ISBN,Pages,LibraryAddDate,CopiesInLibrary,CopiesOutLibrary,AvailableCopies,EVersion,bookcategories,ImageURL")] Books books)
        {
            if (!ModelState.IsValid)
            {
                return View(books);
            }
            _service.Add(books);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var Bookdetails = _service.GetById(id);
            if (Bookdetails == null) return View("Not Found");
            return View(Bookdetails);
        }

        public IActionResult Edit(int id)
        {
            var bookDetails = _service.GetById(id);
            if (bookDetails == null)
            {
                return NotFound();
            }
            return View(bookDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Author,GenreId,Publisher,Language,ISBN,Pages,LibraryAddDate,CopiesInLibrary,CopiesOutLibrary,AvailableCopies,EVersion,bookcategories,ImageURL")] Books books)
        {
            if (id != books.Id)
            {
                return BadRequest(); 
            }

            if (!ModelState.IsValid)
            {
                return View(books);
            }

            try
            {
                await _service.UpdateAsync(books);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }

        public IActionResult Delete(int id)
        {
            var Bookdetails = _service.GetById(id);
            if (Bookdetails == null) return View("Not Found");
            return View(Bookdetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Bookdetails = _service.GetById(id);
            if (Bookdetails == null) return View("Not Found");

            _service.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Filter()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allBooks = await _service.GetAll();
            var filteredBooks = allBooks.Where(book =>
                book.ISBN.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                book.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                book.Author.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                book.Publisher.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                book.CreatedAt.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

            return View("Index", filteredBooks);
        }
    }       
}