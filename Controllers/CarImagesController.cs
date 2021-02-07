using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShiftIn.Models;
using Shiftin.Data;

namespace Shiftin.Controllers
{
    public class CarImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarImage.ToListAsync());
        }

        // GET: CarImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carImage = await _context.CarImage.FirstOrDefaultAsync(m => m.Id == id);
            if (carImage == null)
            {
                return NotFound();
            }

            return View(carImage);
        }

        // GET: CarImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Path,Alt")] CarImage carImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carImage);
        }

        // GET: CarImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carImage = await _context.CarImage.FindAsync(id);
            if (carImage == null)
            {
                return NotFound();
            }
            return View(carImage);
        }

        // GET: CarImages/AddCarImages/{carid}
        public async Task<IActionResult> AddCarImages(int? id)
        {
            //get car
            var Car = await _context.Car.Include(c=>c.CarImages).FirstOrDefaultAsync(c=>c.Id == id);
            if (Car == null)
            {
                return NotFound();
            }            
            else
            {
                return View(Car.CarImages);
                
            }
        }



        // POST: CarImages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Path,Alt")] CarImage carImage)
        {
            if (id != carImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarImageExists(carImage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carImage);
        }

        // GET: CarImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carImage = await _context.CarImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carImage == null)
            {
                return NotFound();
            }

            return View(carImage);
        }

        // POST: CarImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carImage = await _context.CarImage.FindAsync(id);
            _context.CarImage.Remove(carImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarImageExists(int id)
        {
            return _context.CarImage.Any(e => e.Id == id);
        }
    }
}
