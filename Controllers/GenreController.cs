using B_U2_S1_G1_ES.Models.Entity;
using B_U2_S1_G1_ES.Services;
using B_U2_S1_G1_ES.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace B_U2_S1_G1_ES.Controllers
{

    public class GenreController : Controller
    {
        private readonly GenreService _genreService;

        public GenreController(ILogger<GenreController> logger, GenreService genreService)
        {
            _genreService = genreService;
        }


        public async Task<IActionResult>ManageGenre()
        {

            var genres =  await _genreService.GetAllGenres();
            return View(genres);
        }


        public IActionResult AddGenre()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(GenreViewModel genreViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View("AddGenre", genreViewModel);
            }


            var genre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = genreViewModel.Name,
                Description = genreViewModel.Description,
                CreatedAt = DateTime.UtcNow   

            };

            var result = await _genreService.Create(genre);


            if (!result)
            {
                TempData["CreationError"] = "Errore durante la creazione del prodotto";
                return RedirectToAction("AddGenre");
            }




            return RedirectToAction("ManageGenre");


        }

        public IActionResult EditGenre(Guid id)
        {
            var genre = _genreService.GetById(id);
          

            var vm = new GenreViewModel
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description
            };

            return View("EditGenre", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(GenreViewModel vm)
        {
            if (!ModelState.IsValid) return View("EditGenre", vm);

            var genre = _genreService.GetById(vm.Id);
       

            genre.Name = vm.Name;
            genre.Description = vm.Description;

            await _genreService.Update(genre);

           
            return RedirectToAction("ManageGenre");
        }

        public async Task<IActionResult> DeleteGenre(Guid id)
        {
            var genre = _genreService.GetById(id);
            if (genre == null) return NotFound();

            await _genreService.Delete(genre);
            
            return RedirectToAction("ManageGenre");
        }
    }
}

