﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShiftIn.Models;
using Shiftin.Data;
using Microsoft.AspNetCore.Authorization;

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
            return View(await _context.Posts.Where(fp=>fp.ParentId ==0).ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Search(string searchtext)
        {
            return View(await _context.Posts.Where(x => EF.Functions.Like(x.Title, $"%{searchtext}%")).ToListAsync());
        }

        // GET: ForumPosts/Details/5
        public async Task<IActionResult> Details(int? id)
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
            //post is not a reply, will be shown in main thread
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
        // GET: ForumPosts/Reply/5
        public async Task<IActionResult> Reply(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumPost = await _context.Posts.FirstOrDefaultAsync(p=>p.Id == id);
            if (forumPost == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.post = forumPost;
                return View();
            }
            
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reply(int id, [Bind("Title,Body,ParentId")] ForumPost forumPost)
        {
            if (id != forumPost.ParentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(forumPost);
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
        public async Task<IActionResult> LoadThread(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var forumPostog = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if (forumPostog == null)
            {
                return NotFound();
            }
             ViewBag.post = forumPostog;
            //Load replies and their replies
            var forumPost = await _context.Posts.Where(p=>p.ParentId == id).ToListAsync();
            if (forumPost == null)
            {
                return NotFound();
            }
            else
            {

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
