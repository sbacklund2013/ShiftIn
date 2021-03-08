using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShiftIn.Models;
using Shiftin.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Net;

namespace Shiftin.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> SessionCheck()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var profileid = HttpContext.Session.GetInt32("ProfileId");
            if (profileid == null)
            {
                var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.User.Id.Equals(userId));
                if (profile == null)
                {
                    return new ContentResult
                    {
                        ContentType = "text/html",
                        StatusCode = (int)HttpStatusCode.OK,
                        Content = "<p>You need to create a profile before you can do that. </p>"
                    };
                }

                //Return profile view
                Profile userprofile = (Profile)profile;
                HttpContext.Session.SetInt32("ProfileId", userprofile.Id); ;

            }

            return View();
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Events.ToListAsync());
        }
        public async Task<IActionResult> YourEvents()
        {
            //Get logged in User
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            //Check if profileid is in the session
            var profileid = HttpContext.Session.GetInt32("ProfileId");
            if (profileid != null)
            {
                //Profile exists
                return View(await _context.Events.Include(pr => pr.Attendees).Include(pr => pr.Creator).Where(pid => pid.Creator.Id.Equals(userId)).ToListAsync());
            }
            else
            {
                //Check if user has profile
                var profile = await _context.Profiles.Include(pr => pr.Interests).Include(pr => pr.Cars).ThenInclude(c => c.CarImages).FirstOrDefaultAsync(p => p.User.Id.Equals(userId));
                if (profile == null)
                {
                    return RedirectToAction("Create","Profiles");
                }
                else
                {
                    //Return profile view
                    Profile userprofile = (Profile)profile;
                    HttpContext.Session.SetInt32("ProfileId", userprofile.Id);
                    return View(await _context.Events.Include(pr => pr.Attendees).Include(pr => pr.Creator).Where(pid => pid.Creator.Id.Equals(userId)).ToListAsync());
                }
            }

        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.Include(e => e.Attendees)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }
        public async Task<IActionResult> Attend(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.Include(e => e.Attendees)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }
            var profileid = HttpContext.Session.GetInt32("ProfileId");
            if (profileid != null)
            {
                //RSVP for event
                Profile prof = (Profile)await _context.Profiles.Include(pr => pr.Meets).FirstOrDefaultAsync(pid => pid.Id.Equals(profileid));
                if (!@event.Attendees.Contains(prof))
                {
                    @event.Attendees.Add(prof);
                    _context.SaveChanges();
                }
                return View("Details", @event);
            }
            else
            {
                //no profile session set
                //check db
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
                var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.User.Id.Equals(userId));
                if (profile == null)
                {
                    return View("ProfileError");
                }

                //Return profile view
                Profile userprofile = (Profile)profile;
                HttpContext.Session.SetInt32("ProfileId", userprofile.Id); 

            }
            
            return View("Details", @event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Location")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Location")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
