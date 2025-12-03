using B_U2_S1_G1_ES.Models.Entity;
using B_U2_S1_G1_ES.Services;
using B_U2_S1_G1_ES.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace B_U2_S1_G1_ES.Controllers
{
    public class BookController : Controller
    {

        private readonly BookService _bookService;

        public BookController(ILogger<BookController> logger, BookService bookService)
        {           
            _bookService = bookService;
        }

        //Grid
        public IActionResult ManageBook()
       {
            
           var books = _bookService.GetAllBooks();
          return View(books); 
       }
       



        //AddBook
        public IActionResult AddBook()
        {
            var bookVm = new AddBookViewModel();
            return View(bookVm); 
        }

        [HttpPost]
        public IActionResult Save(AddBookViewModel addBookViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View("AddBook", addBookViewModel);
            }


            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = addBookViewModel.Title,
                Author = addBookViewModel.Author,
                //Genre = addBookViewModel.Genre,
                IsAvailable = addBookViewModel.IsAvailable,
                CoverImage = addBookViewModel.CoverImage
            };

            var result = _bookService.Create(book);
            if (!result)
            {
                TempData["CreationError"] = "Errore durante la creazione del prodotto";
                return RedirectToAction("AddBook"); 
            }
            
               
            

            return RedirectToAction("ManageBook");


        }


        //Get Single Book to Edit
        [HttpGet]
        public IActionResult EditBook(Guid id)
        {
            var book = _bookService.GetBookById(id);

            if (book == null)
            { 
                return NotFound(); 
            }

            var viewModel = new AddBookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                IsAvailable = book.IsAvailable,
                CoverImage = book.CoverImage
            };

            return View(viewModel);


        }

        //edit
        [HttpPost]
        public IActionResult UpdateBook(AddBookViewModel addBookViewModel)
        {
            if (!ModelState.IsValid)
                return View("EditBook", addBookViewModel);

            var book = new Book
            {
                Id = addBookViewModel.Id,
                Title = addBookViewModel.Title,
                Author = addBookViewModel.Author,
                //Genre = addBookViewModel.Genre,
                IsAvailable = addBookViewModel.IsAvailable,
                CoverImage = addBookViewModel.CoverImage
            };

            var success = _bookService.Update(book);

            return RedirectToAction("ManageBook");
        }

        public IActionResult DeleteBook(Guid id)
        {
            var result = _bookService.Delete(id);

            if (!result)
                return NotFound();

            return RedirectToAction("ManageBook");
        }


    }
}
