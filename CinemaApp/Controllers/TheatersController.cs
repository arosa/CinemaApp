using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace CinemaApp.Controllers
{
    public class TheatersController : Controller
    {
        private readonly MVCCinemaDBContext mvc;

        public TheatersController(MVCCinemaDBContext mvc)
        {
            this.mvc = mvc;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var theaters = await mvc.Theaters.ToListAsync();
            return View(theaters);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTheaterViewModel addTheaterRequest)
        {
            var theater = new Theater()
            {
                Id = Guid.NewGuid(),
                Name = addTheaterRequest.Name,
                City = addTheaterRequest.City,
                TicketPrice = addTheaterRequest.TicketPrice,
                OpenHoursFrom = addTheaterRequest.OpenHoursFrom,
                OpenHoursTo = addTheaterRequest.OpenHoursTo
            };
            //return View(theater);
            await mvc.Theaters.AddAsync(theater);
            await mvc.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid ID)
        {
            var theater = await mvc.Theaters.FirstOrDefaultAsync(x => x.Id == ID);

            if (theater != null)
            {
                var viewModel = new UpdateTheaterViewModel()
                {
                    Id = theater.Id,
                    Name = theater.Name,
                    City = theater.City,
                    TicketPrice = theater.TicketPrice,
                    OpenHoursFrom = theater.OpenHoursFrom,
                    OpenHoursTo = theater.OpenHoursTo
                };
                return await Task.Run(() => View("Edit",viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateTheaterViewModel model)
        {
            var rec = await mvc.Theaters.FindAsync(model.Id);

            if (rec != null)
            {
                rec.Id = model.Id;
                rec.Name = model.Name;
                rec.City = model.City;
                rec.TicketPrice = model.TicketPrice;
                rec.OpenHoursFrom = model.OpenHoursFrom;
                rec.OpenHoursTo = model.OpenHoursTo;

                await mvc.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid ID)
        {
            var theater = await mvc.Theaters.FirstOrDefaultAsync(x => x.Id == ID);

            if (theater != null)
            {
                var viewModel = new UpdateTheaterViewModel()
                {
                    Id = theater.Id,
                    Name = theater.Name,
                    City = theater.City,
                    TicketPrice = theater.TicketPrice,
                    OpenHoursFrom = theater.OpenHoursFrom,
                    OpenHoursTo = theater.OpenHoursTo
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateTheaterViewModel model)
        {
            var rec = await mvc.Theaters.FindAsync(model.Id);

            if (rec != null)
            {
                mvc.Theaters.Remove(rec);
                await mvc.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }

    }
}
