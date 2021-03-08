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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Shiftin.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public CarsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            //for io
            _environment = environment;
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
                    ViewBag.MSG("You need to make a profile first");
                    return View("Error");
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
                var model = new Car();
                model.CarImages.Add(new CarImage());
                return View(model);
            }
            else
            {
                return RedirectToAction("Profiles", "Create");
            }
        }

        /**
         * Used to add multple images when creating a car
         * 
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddCarImage([Bind("Id,Name,Year,Make,Model,Description,ProfileId,CarImages")] Car car)
        {
            
            car.CarImages.Add(new CarImage());
            return PartialView("CarImages", car);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveCarImage([Bind("Id,Name,Year,Make,Model,Description,ProfileId,CarImages")] Car car,int carimage)
        {
            var existingParent = _context.Car
               .Where(p => p.Id == car.Id)
               .Include(p => p.CarImages)
               .SingleOrDefault();

            if (existingParent != null)
            {
                // Update parent
                _context.Entry(existingParent).CurrentValues.SetValues(car);
                var existingchild = existingParent.CarImages.First(Ci => Ci.Id == carimage);
                // Delete children
                if (existingchild != null)
                {
                    existingParent.CarImages.Remove(existingchild);
                    _context.CarImage.Remove(existingchild);
                }
                _context.SaveChanges();
            }
            return PartialView("CarImages", existingParent);
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Make,Year,Model,Description,CarImages")] Car car)
        {
            var profileid = HttpContext.Session.GetInt32("ProfileId");
            Profile Profile = (Profile)await _context.Profiles.Include(prof=>prof.Cars).FirstOrDefaultAsync(pid => pid.Id == profileid);
            if (ModelState.IsValid)
            {
                if (car.CarImages.Count > 0)
                {
                    foreach (CarImage carImage in car.CarImages)
                    {
                        if (carImage.Upload != null)
                        {
                            try
                            {
                                /////////////////////GET UPLOADED FILE////////////////////////////
                                string storagepathforuser = "wwwroot/CarImages/" + profileid.ToString() + "/";
                                // Determine whether the directory exists.
                                if (!Directory.Exists(storagepathforuser))
                                {                                    // Try to create the directory.
                                    DirectoryInfo di = Directory.CreateDirectory(storagepathforuser);
                                }
                                var file = Path.Combine(_environment.ContentRootPath, storagepathforuser, carImage.Upload.FileName);
                                using (var fileStream = new FileStream(file, FileMode.Create))
                                {
                                    await carImage.Upload.CopyToAsync(fileStream);
                                }
                                //SET DIRECTORY                            
                                carImage.Path = "/CarImages/" + profileid.ToString() + "/" + carImage.Upload.FileName;
                            }
                            catch (Exception e)
                            {
                                ViewBag.MSG("There was an error in the file upload :(");
                                return View("Error");
                            }
                        }
                    }
                }
                if (Profile.Cars == null)
                {
                    Profile.Cars = new List<Car>();
                }
                Profile.Cars.Add(car);

                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Profiles");
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
            
            var car = await _context.Car.Include(c=>c.CarImages).FirstOrDefaultAsync(c=>c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                if(car.ProfileId == HttpContext.Session.GetInt32("ProfileId"))
                {
                    return View(car);
                }
                else
                {
                    ViewBag.MSG("You do not own this one ;)");
                    return View("Error");
                }
            }
           
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Year,Make,Model,Description,ProfileId,CarImages")] Car car)
        {
            var profileid = HttpContext.Session.GetInt32("ProfileId");
            if (id != car.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {

                    if (car.ProfileId != profileid)
                    {
                        return View("Error");
                    }
                    var existingParent = _context.Car.Where(p => p.Id == car.Id).Include(p => p.CarImages).SingleOrDefault();

                    if (existingParent != null)
                    {
                        // Update parent
                        _context.Entry(existingParent).CurrentValues.SetValues(car);

                        // Update and Insert children
                        foreach (var childModel in car.CarImages)
                        {
                            var existingChild = existingParent.CarImages
                                .Where(c => c.Id == childModel.Id)
                                .SingleOrDefault();

                            if (existingChild != null)
                            {
                                if (childModel.Upload != null)
                                {
                                    //exists
                                    /////////////////////GET UPLOADED FILE////////////////////////////
                                    string storagepathforuser = "wwwroot/CarImages/" + profileid.ToString() + "/";
                                    // Determine whether the directory exists.
                                    if (!Directory.Exists(storagepathforuser))
                                    {                                    // Try to create the directory.
                                        Directory.CreateDirectory(storagepathforuser);
                                    }
                                    var file = Path.Combine(_environment.ContentRootPath, storagepathforuser, childModel.Upload.FileName);
                                    using (var fileStream = new FileStream(file, FileMode.Create))
                                    {
                                        await childModel.Upload.CopyToAsync(fileStream);
                                    }
                                    //SET DIRECTORY                            
                                    childModel.Path = "/CarImages/" + profileid.ToString() + "/" + childModel.Upload.FileName;
                                    _context.Entry(existingChild).CurrentValues.SetValues(childModel);
                                }
                                
                            }
                            else
                            {
                                // Insert child
                                /////////////////////GET UPLOADED FILE////////////////////////////
                                string storagepathforuser = "wwwroot/CarImages/" + profileid.ToString() + "/";
                                // Determine whether the directory exists.
                                if (!Directory.Exists(storagepathforuser))
                                {                                    // Try to create the directory.
                                    Directory.CreateDirectory(storagepathforuser);
                                }
                                var file = Path.Combine(_environment.ContentRootPath, storagepathforuser, childModel.Upload.FileName);
                                string filename = storagepathforuser + childModel.Upload.FileName;
                                if (System.IO.File.Exists(filename))
                                {
                                    System.IO.File.Delete(filename);
                                }
                                // Try to create the directory.
                                    DirectoryInfo di = Directory.CreateDirectory(storagepathforuser);
                                    using (var fileStream = new FileStream(file, FileMode.Create))
                                    {
                                        await childModel.Upload.CopyToAsync(fileStream);
                                    }
                                
                                //SET DIRECTORY                            
                                childModel.Path = "/CarImages/" + profileid.ToString() + "/" + childModel.Upload.FileName;
                                existingParent.CarImages.Add(childModel);

                            }
                            
                        }
                        
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }
                catch (Exception e)
                {
                    return View("Error");
                }
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
