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

        private List<Theater> theaters;

        public MoviesController(MVCCinemaDBContext mvc)
        {
            this.mvc = mvc;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var movies = await mvc.Movies
              .Join(
                mvc.Theaters, // Join with Theaters table
                movie => movie.TheaterID, // Join on Movie's TheaterID
                theater => theater.Id,     // Join on Theater's Id
                (movie, theater) => new IndexMovieViewModel
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    PremiereDate = movie.PremiereDate,
                    FinalDate = movie.FinalDate,
                    TheaterID = movie.TheaterID, // Retrieve theater ID
                    TheaterName = theater.Name   // Retrieve theater name
                }
              ).ToListAsync();

            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            theaters = await mvc.Theaters.ToListAsync();
            ViewBag.Theaters = new SelectList(theaters, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel model)
        {
            var movie = new Movie()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                TheaterID = model.TheaterID,
                PremiereDate = model.PremiereDate,    
                FinalDate = model.FinalDate,
            };

            await mvc.Movies.AddAsync(movie);
            await mvc.SaveChangesAsync();
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid ID)
        {
            theaters = await mvc.Theaters.ToListAsync();
            ViewBag.Theaters = new SelectList(theaters, "Id", "Name");

            var movie = await mvc.Movies.FirstOrDefaultAsync(x => x.Id == ID);

            if (movie != null)
            {
                var model = await mvc.Movies
                    .Where(movie => movie.Id == ID)
                  .Join(
                    mvc.Theaters, // Join with Theaters table
                    movie => movie.TheaterID, // Join on Movie's TheaterID
                    theater => theater.Id,     // Join on Theater's Id
                    (movie, theater) => new UpdateMovieViewModel
                    {
                        Id = movie.Id,
                        Name = movie.Name,
                        PremiereDate = movie.PremiereDate,
                        FinalDate = movie.FinalDate,
                        TheaterID = movie.TheaterID, // Retrieve theater ID
                        TheaterName = theater.Name   // Retrieve theater name
                    }
                  ).FirstOrDefaultAsync();

                return await Task.Run(() => View("Edit", model));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateMovieViewModel model)
        {
            var rec = await mvc.Movies.FindAsync(model.Id);

            if (rec != null)
            {
                rec.Id = model.Id;
                rec.Name = model.Name;
                rec.TheaterID = model.TheaterID;
                rec.PremiereDate = model.PremiereDate;
                rec.FinalDate = model.FinalDate;

                await mvc.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid ID)
        {

            var movie = await mvc.Movies.FirstOrDefaultAsync(x => x.Id == ID);

            if (movie != null)
            {
                var viewModel = await mvc.Movies
                    .Where(movie => movie.Id == ID)
                  .Join(
                    mvc.Theaters, // Join with Theaters table
                    movie => movie.TheaterID, // Join on Movie's TheaterID
                    theater => theater.Id,     // Join on Theater's Id
                    (movie, theater) => new IndexMovieViewModel
                    {
                        Id = movie.Id,
                        Name = movie.Name,
                        PremiereDate = movie.PremiereDate,
                        FinalDate = movie.FinalDate,
                        TheaterID = movie.TheaterID, // Retrieve theater ID
                        TheaterName = theater.Name   // Retrieve theater name
                    }
                  ).FirstOrDefaultAsync();

                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateTheaterViewModel model)
        {
            var rec = await mvc.Movies.FindAsync(model.Id);

            if (rec != null)
            {
                mvc.Movies.Remove(rec);
                await mvc.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }

    }
}
