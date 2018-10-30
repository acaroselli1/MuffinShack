using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuffinShack.Data;
using MuffinShack.Entities;

namespace MuffinShack.Web.Controllers
{
    public class MuffinsController : Controller
    {
        private readonly MuffinContext _context;

        public MuffinsController(MuffinContext context)
        {
            _context = context;
        }

        // GET: Muffins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Muffins.ToListAsync());
        }

        // GET: Muffins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muffin = await _context.Muffins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (muffin == null)
            {
                return NotFound();
            }

            return View(muffin);
        }

        // GET: Muffins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Muffins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Size")] Muffin muffin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(muffin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(muffin);
        }

        // GET: Muffins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muffin = await _context.Muffins.FindAsync(id);
            if (muffin == null)
            {
                return NotFound();
            }
            return View(muffin);
        }

        // POST: Muffins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Size")] Muffin muffin)
        {
            if (id != muffin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(muffin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MuffinExists(muffin.Id))
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
            return View(muffin);
        }

        // GET: Muffins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muffin = await _context.Muffins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (muffin == null)
            {
                return NotFound();
            }

            return View(muffin);
        }

        // POST: Muffins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var muffin = await _context.Muffins.FindAsync(id);
            _context.Muffins.Remove(muffin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MuffinExists(int id)
        {
            return _context.Muffins.Any(e => e.Id == id);
        }
    }
}
