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
using Newtonsoft.Json.Serialization;
using System.Security.Claims;

namespace Shiftin.Controllers
{
    [Authorize]
    public class ForumPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForumPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ForumPosts
        public async Task<IActionResult> Index()
        {
            //Get logged in User
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            //Check if profileid is in the session
            var profileid = HttpContext.Session.GetInt32("ProfileId");
            if (profileid == null)
            {
                var profile = await _context.Profiles.Include(pr => pr.Interests).Include(pr => pr.Cars).ThenInclude(c => c.CarImages).FirstOrDefaultAsync(p => p.User.Id.Equals(userId));
                if (profile != null)
                {
                    //Return profile view
                    Profile userprofile = (Profile)profile;
                    HttpContext.Session.SetInt32("ProfileId", userprofile.Id);
                }
            }
            var forumPost = await _context.Posts.Include("Author").Where(fp => fp.ParentId == 0).ToListAsync();
            foreach(ForumPost post in forumPost)
            {
                post.Likes = CountLikes(post.Id);
            }
            return View(forumPost);
        }
        [HttpPost]
        public async Task<IActionResult> Search(string searchtext)
        {
            return View(await _context.Posts.Include(fp => fp.Author).Where(x => EF.Functions.Like(x.Title, $"%{searchtext}%")).ToListAsync());
        }

        // GET: ForumPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumPost = await _context.Posts.Include(fp => fp.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumPost == null)
            {
                return NotFound();
            }

            return View(forumPost);
        }

        // GET: ForumPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForumPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Body")] ForumPost forumPost)
        {
            var profileid = HttpContext.Session.GetInt32("ProfileId");
            if (profileid == null)
            {
                return View("ProfileError");
            }
            //post is not a reply, will be shown in main thread
            forumPost.AuthorId = profileid.GetValueOrDefault();
            forumPost.ParentId = 0;
            if (ModelState.IsValid)
            {
                _context.Add(forumPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forumPost);
        }

        // GET: ForumPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumPost = await _context.Posts.FindAsync(id);
            if (forumPost == null)
            {
                return NotFound();
            }
            return View(forumPost);
        }
        [HttpPost]
        public IActionResult SubmitReply(ForumPost ForumPost)
        {
            int parentid = ForumPost.ParentId;
            if (ForumPost == null)
            {
                return null;
            }
            else
            {
                var profileid = HttpContext.Session.GetInt32("ProfileId");
                if (profileid == null)
                {
                    return View("ProfileError");
                }
                else
                {
                    ForumPost.AuthorId = (int) profileid;
                    _context.Posts.Add(ForumPost);
                    _context.SaveChanges();
                }                
                return RedirectToAction("LoadThread", new { id = parentid });

            }

        }
        
        public int CountLikes(int id)
        {            
            //load original post
            var likes = _context.Likes.Where(fp => fp.PostId == id).ToList();
            if (likes.Count() == 0)
            {
                return 0;
            }
            else
            {
                return likes.Count();
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> LoadReplies(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //load original post
            var forumPostog = await _context.Posts.Include(fp => fp.Author).FirstOrDefaultAsync(p => p.Id == id);
            if (forumPostog == null)
            {
                return NotFound();
            }
            //Load replies and their replies
            var forumPost = await _context.Posts.Include(fp => fp.Author).Where(p => p.ParentId == id).ToListAsync();
            if (forumPost == null)
            {
                return PartialView("_Replies",null);
            }
            else
            {
                //found some replies to load
                foreach(ForumPost post in forumPost)
                {
                    post.Likes = CountLikes(post.Id);
                }
                return PartialView("_Replies", forumPost);
            }
        }
        [HttpPost]
        public IActionResult Reply(int id)
        {
            ForumPost fp = _context.Posts.FirstOrDefault(f => f.Id == id);
            if(fp == null)
            {
                return null;
            }
            else
            {
                
                fp.Likes = CountLikes(fp.Id);
                return PartialView("_Reply", fp);
            }
            
        }
        //Like
        [HttpPost]
        public int Upvote(int id)
        {
            //check profile logged in
            var profileid = HttpContext.Session.GetInt32("ProfileId");
            if (profileid == null)
            {
                return 0;
            }
            //check if already liked
            List<Like> existing = (List<Like>)_context.Likes.Where(p => p.PostId == id && p.ProfileId == (int) profileid).ToList();
            List<Like> existingtotal = (List<Like>)_context.Likes.Where(p => p.PostId == id).ToList();
            if (existing.Count >= 1)
            {
                return existingtotal.Count;
            }
            //gopher it
            else
            {
                Like newlike = new Like();
                newlike.PostId = id;
                newlike.ProfileId = profileid.GetValueOrDefault();
                _context.Add(newlike);
                _context.SaveChangesAsync();
                return existingtotal.Count +1;
            }
        }

   
        public async Task<IActionResult> LoadThread(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var forumPostog = await _context.Posts.Include(fp => fp.Author).FirstOrDefaultAsync(p => p.Id == id);
            if (forumPostog == null)
            {
                return NotFound();
            }
             ViewBag.post = forumPostog;
            //Load replies and their replies
            var forumPost = await _context.Posts.Include(fp => fp.Author).Where(p=>p.ParentId == id).ToListAsync();
            if (forumPost == null)
            {
                return NotFound();
            }
            else
            {
                foreach (ForumPost post in forumPost)
                {
                    post.Likes = CountLikes(post.Id);
                }
            }
            return View(forumPost);
        }
        // POST: ForumPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Body,ParentId")] ForumPost forumPost)
        {
            if (id != forumPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forumPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumPostExists(forumPost.Id))
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
            return View(forumPost);
        }

        // GET: ForumPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumPost = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumPost == null)
            {
                return NotFound();
            }

            return View(forumPost);
        }

        // POST: ForumPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forumPost = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(forumPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumPostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
