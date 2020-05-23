using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Philosophers_Application.Data;
using Philosophers_Application.Models;
using Philosophers_Application.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Philosophers_Application.Controllers
{
    [Route("[controller]")]
    public class PhilosophersController : Controller
    {
        PhilosophersDbContext _context;

        public PhilosophersController(PhilosophersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<PhilosophersModelView>> Index(string? searchline)
        {
            var philosphers = await _context.Philosophers
                .Include(c => c.Country)
                .Include(pd => pd.PhilosopherDirection)
                    .ThenInclude(p => p.Direction)
                .ToListAsync();

            if (searchline != null)
                philosphers = philosphers.Where(p => p.PhilosopherName.Contains(searchline)).ToList();

            var philosophersmv = new PhilosophersModelView() { Philosophers = philosphers };

            return View(philosophersmv);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Create()
        {
            PhilosopherModelView philosopherMV = new PhilosopherModelView();

            foreach (var country in _context.Countries)
                philosopherMV.Countries.Add(new SelectListItem()
                {
                    Text = country.CountryName,
                    Value = country.Id.ToString()
                });

            foreach (var direction in _context.Directions)
                philosopherMV.Directions.Add(new SelectListItem()
                {
                    Text = direction.DirectionName,
                    Value = direction.Id.ToString()
                });

            return View(philosopherMV);
        }

        [HttpPost]
        [Route("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SelectedCountry,SelectedDirections,TypedName")]PhilosopherModelView createmv)
        {
            if (createmv == null || createmv.Directions == null || createmv.Countries == null)
                return RedirectToPage("/Index");

            if (ModelState.IsValid)
            {
                var directions = new List<Direction>();
                var directionSrcs = await _context.Directions.ToListAsync();

                foreach (var directionName in createmv.SelectedDirections)
                    foreach (var direction in directionSrcs)
                        if (directionName == direction.DirectionName)
                        { 
                            directions.Add(direction);
                            continue;
                        }

                var philosopher = new Philosopher()
                {
                    PhilosopherName = createmv.TypedName,
                    Country = await _context.Countries.FirstAsync(c => c.CountryName == createmv.SelectedCountry)
                };

                foreach (var dir in directions)
                    philosopher.PhilosopherDirection.Add(new PhilosopherDirection() { Direction = dir, Philosopher = philosopher });

                await _context.Philosophers.AddAsync(philosopher);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            _context.Philosophers.Remove(await _context.Philosophers.FirstAsync(ph => ph.Id == id));
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var srcPhilospher = await _context.Philosophers.FirstAsync(p => p.Id == id);

                // init id, name, selectedCountry, selectedDirections
                var philosopherMV = new PhilosopherModelView()
                {
                    Id = srcPhilospher.Id,
                    TypedName = srcPhilospher.PhilosopherName,
                    SelectedCountry = (await _context.Countries
                                                     .FirstAsync(c => c.Id == srcPhilospher.CountryId))
                                                     .CountryName,
                    SelectedDirections = (from dir in srcPhilospher.PhilosopherDirection
                                          select dir.Direction.DirectionName).ToList()
                };
                // init countries
                foreach (var country in _context.Countries)
                    philosopherMV.Countries.Add(new SelectListItem()
                    {
                        Text = country.CountryName,
                        Value = country.Id.ToString()
                    });
                // init directions
                foreach (var direction in _context.Directions)
                    philosopherMV.Directions.Add(new SelectListItem()
                    {
                        Text = direction.DirectionName,
                        Value = direction.Id.ToString()
                    });

                return View(philosopherMV);
            }

            return RedirectToPage("/Index");
        }

        [HttpPost]
        [Route("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,SelectedCountry,SelectedDirections,TypedName")]PhilosopherModelView editmv)
        {
            if (editmv == null || editmv.SelectedCountry == null || editmv.SelectedCountry == null)
                return RedirectToAction(nameof(Index));

            if (ModelState.IsValid)
            {
                var src = await _context.Philosophers
                    .Include(pd => pd.PhilosopherDirection)
                    .FirstAsync(p => p.Id == editmv.Id);

                src.PhilosopherDirection.Clear();
                src.Country = await _context.Countries.FirstAsync(c => c.CountryName == editmv.SelectedCountry);
                src.PhilosopherName = editmv.TypedName;

                var srcDirs = await _context.Directions.ToListAsync();
                foreach (var dirName in editmv.SelectedDirections)
                    foreach (var dir in srcDirs)
                        if (dirName == dir.DirectionName)
                        {
                            src.PhilosopherDirection.Add(new PhilosopherDirection() { Direction = dir, Philosopher = src });
                            continue;
                        }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
