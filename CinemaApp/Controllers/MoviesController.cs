using CinemaApp.Data;
using CinemaApp.Models.Domain;
using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MVCCinemaDBContext mvc;

        public MoviesController(MVCCinemaDBContext mvc)
        {
            this.mvc = mvc;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var movies = await mvc.Movies.ToListAsync();
            return View(movies);
        }

       

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var theaters = await mvc.Theaters.ToListAsync();
            ViewBag.Theaters = new SelectList(theaters, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel addMovieRequest)
        {
            var movie = new Movie()
            {
                Id = Guid.NewGuid(),
                Name = addMovieRequest.Name,
                Theater = addMovieRequest.Theater,
                PremiereDate = addMovieRequest.PremiereDate,    
                FinalDate = addMovieRequest.FinalDate,
            };

            await mvc.Movies.AddAsync(movie);
            await mvc.SaveChangesAsync();
            return RedirectToAction("Add");
        }

    }
}
