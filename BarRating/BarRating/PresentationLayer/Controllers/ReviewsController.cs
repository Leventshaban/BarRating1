using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PresentationLayer.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly SigmaBarRatingDbContext _context;

        public ReviewsController(SigmaBarRatingDbContext context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reviews.ToListAsync());
        }

        public async Task<IActionResult> IndexUser()
        {
            return View(await _context.Reviews.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SortUsers()
        {
            List<Review> SortedReviews = new List<Review>();
            SortedReviews = _context.Reviews.OrderByDescending(r => r.User_Id).ToList();
            if (_context.Users.FirstOrDefault(u => u.Id == (int)ViewData["UserId"]).Role == Role.Admin)
            {
                return View("Index", SortedReviews);
                //return RedirectToAction(nameof(IndexUser));
            }
            else
            {
                return View("IndexUser", SortedReviews);
            }
        }
        public IActionResult SortAll()
        {
            List<Review> SortedReviews = new List<Review>();
            SortedReviews = _context.Reviews.OrderByDescending(r => r.User_Id).ToList();
            if (_context.Users.FirstOrDefault(u => u.Id == (int)ViewData["UserId"]).Role == Role.Admin)
            {
                return View("Index", SortedReviews);
                //return RedirectToAction(nameof(IndexUser));
            }
            else
            {
                return View("IndexUser", SortedReviews);
            }
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User_Id,Bar_Id,Text")] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                ViewData["UserId"] = review.User_Id;
                var user = await _context.Users.FindAsync(review.User_Id);
                if (user.Role == Role.User)
                {
                    return RedirectToAction(nameof(IndexUser));
                }
                else
                { 
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,User_Id,Bar_Id,Text")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.Id))
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
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
