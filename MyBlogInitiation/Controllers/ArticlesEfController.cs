using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlogInitiation.Data;
using MyBlogInitiation.Models;
using MyBlogInitiation.Repository.Context;

namespace MyBlogInitiation.Controllers
{
    public class ArticlesEfController : Controller
    {
        //private readonly MyBlogInitiationContext _context;
        private readonly DbBlogContext _context;
        public ArticlesEfController(DbBlogContext context)
        {
            _context = context;
        }

        // GET: ArticlesEf
        public async Task<IActionResult> Index()
        {
              return View(await _context.Articles.ToListAsync());
        }

        // GET: ArticlesEf/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var articleModel = await _context.Articles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articleModel == null)
            {
                return NotFound();
            }

            return View(articleModel);
        }

        // GET: ArticlesEf/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArticlesEf/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content")] ArticleModel articleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articleModel);
        }

        // GET: ArticlesEf/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var articleModel = await _context.Articles.FindAsync(id);
            if (articleModel == null)
            {
                return NotFound();
            }
            return View(articleModel);
        }

        // POST: ArticlesEf/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content")] ArticleModel articleModel)
        {
            if (id != articleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleModelExists(articleModel.Id))
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
            return View(articleModel);
        }

        // GET: ArticlesEf/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var articleModel = await _context.Articles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articleModel == null)
            {
                return NotFound();
            }

            return View(articleModel);
        }

        // POST: ArticlesEf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Articles == null)
            {
                return Problem("Entity set 'MyBlogInitiationContext.ArticleModel'  is null.");
            }
            var articleModel = await _context.Articles.FindAsync(id);
            if (articleModel != null)
            {
                _context.Articles.Remove(articleModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleModelExists(int id)
        {
          return _context.Articles.Any(e => e.Id == id);
        }
    }
}
