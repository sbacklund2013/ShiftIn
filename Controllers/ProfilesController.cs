using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShiftIn.Models;
using Shiftin.Data;
using Microsoft.AspNetCore.Identity;
using Shiftin.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Shiftin.Controllers
{
    public class ProfilesController : Controller
    {
        //imageupload for path        
        private readonly IWebHostEnvironment _environment;
        ///

        private readonly ApplicationDbContext _context;
        //identity framework user session management
        private readonly UserManager<ApplicationUser> _userManager;
        public ProfilesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            //for io
            _environment = environment;
        }

        // GET: Profile
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var profileid = HttpContext.Session.GetInt32("ProfileId");
            if(profileid != null)
            {
                return View(await _context.Profiles.Include(pr => pr.Interests).Include(pr => pr.Cars).FirstOrDefaultAsync(pid => pid.Id.Equals(profileid)));
            }
            else
            {
                //Check if user has profile
                var profile = await _context.Profiles.Include(pr=>pr.Interests).Include(pr=>pr.Cars).FirstOrDefaultAsync(p => p.User.Id.Equals(userId));
                if (profile == null)
                {
                    return RedirectToAction(nameof(Create));
                }
                else
                {
                    //Return profile view
                    Profile userprofile = (Profile)profile;
                    HttpContext.Session.SetInt32("ProfileId", userprofile.Id);
                    return View(userprofile);
                }
            }
            
            
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // GET: Profiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Picture,Location,Upload")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                profile.User =await _userManager.GetUserAsync(User);

                if (profile.Upload != null)
                {
                    try
                    {
                        /////////////////////GET UPLOADED FILE////////////////////////////
                        var file = Path.Combine(_environment.ContentRootPath, "wwwroot/ProfileImages", profile.Upload.FileName);
                        using (var fileStream = new FileStream(file, FileMode.Create))
                        {
                            await profile.Upload.CopyToAsync(fileStream);
                        }
                        //SET DIRECTORY
                        profile.Picture = "/ProfileImages/" + profile.Upload.FileName;
                        /////////////////////////////////////////////////////////////////////////////////////
                    }
                    catch (Exception e)
                    {
                        //error page
                    }
                }

                _context.Add(profile);
                var result =await _context.SaveChangesAsync();
                Console.Out.WriteLine(result.ToString());
                if (result> 0)
                {
                    HttpContext.Session.SetInt32("ProfileId", profile.Id );
                    return RedirectToAction("Index","Interests");
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View(profile);
        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Picture,Location")] Profile profile)
        {
            if (id != profile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileExists(profile.Id))
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
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }
    }
}
