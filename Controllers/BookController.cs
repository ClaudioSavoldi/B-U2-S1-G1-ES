using B_U2_S1_G1_ES.Models.Entity;
using B_U2_S1_G1_ES.Services;
using B_U2_S1_G1_ES.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace B_U2_S1_G1_ES.Controllers
{
    public class BookController : Controller
    {

        private readonly BookService _bookService;

        public BookController(ILogger<BookController> logger, BookService bookService)
        {           
            _bookService = bookService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(AddBookViewModel addBookViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View("Index", addBookViewModel);
            }


            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = addBookViewModel.Title,
                Author = addBookViewModel.Author,
                Genre = addBookViewModel.Genre,
                IsAvailable = addBookViewModel.IsAvailable,
                CoverImage = addBookViewModel.CoverImage
            };

            var result = _bookService.Create(book);
            if (!result)
            {
                TempData["CreationError"] = "Errore durante la creazione del prodotto";
                return RedirectToAction("Index", "Book"); 
            }
            
               
            

            return RedirectToAction("Index");


        }



    }
}
