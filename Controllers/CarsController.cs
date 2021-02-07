using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShiftIn.Models;
using Shiftin.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Shiftin.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var profileid = HttpContext.Session.GetInt32("ProfileId");
            if (profileid != null)
            {
                var profile = await _context.Profiles.Include(pr => pr.Cars).ThenInclude(c => c.CarImages).FirstOrDefaultAsync(pid => pid.Id.Equals(profileid));
                Profile userprofile = (Profile)profile;
                return View(userprofile.Cars);
            }
            else
            {
                //Check if user has profile
                var profile = await _context.Profiles.Include(pr => pr.Interests).Include(pr => pr.Cars).ThenInclude(c => c.CarImages).FirstOrDefaultAsync(p => p.User.Id.Equals(userId));
                if (profile == null)
                {
                    return View("ProfileError");
                }
                else
                {
                    //Return profile view
                    Profile userprofile = (Profile)profile;
                    HttpContext.Session.SetInt32("ProfileId", userprofile.Id);
                    return View(userprofile.Cars);
                }
            }

        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            var profileid = HttpContext.Session.GetInt32("ProfileId");
            if (profileid != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Profiles", "Create");
            }
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Make,Year,Model,Description")] Car car)
        {
            var profileid = HttpContext.Session.GetInt32("ProfileId");
            Profile Profile = (Profile)await _context.Profiles.Include(prof=>prof.Cars).FirstOrDefaultAsync(pid => pid.Id == profileid);
            if (ModelState.IsValid)
            {
                if (Profile.Cars == null)
                {
                    Profile.Cars = new List<Car>();
                }
                Profile.Cars.Add(car);

                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Year,Model,Description")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.Id == id);
        }
    }
}
