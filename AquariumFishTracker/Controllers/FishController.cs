using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AquariumFishTracker.Data;
using AquariumFishTracker.Models;

namespace AquariumFishTracker.Controllers
{
    public class FishController : Controller
    {
        private readonly AquariumContext _context;

        public FishController(AquariumContext context)
        {
            _context = context;
        }

        // GET: Fish — PUBLIC, anyone can view the list
        public async Task<IActionResult> Index()
        {
            var fishList = _context.Fish.Include(f => f.Tank);
            return View(await fishList.ToListAsync());
        }

        // GET: Fish/Details/5 — PUBLIC
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var fish = await _context.Fish
                .Include(f => f.Tank)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (fish == null) return NotFound();

            return View(fish);
        }

        // GET: Fish/Create — PRIVATE

        [Authorize]

        public IActionResult Create()
        {
            ViewData["Title"] = "Create Fish";
            ViewData["Action"] = "Create";
            ViewData["TankId"] = new SelectList(_context.Tanks, "Id", "Name");
            return View();
        }

        // POST: Fish/Create — PRIVATE

        [Authorize]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fish fish)
        {
            if (ModelState.IsValid)
            {
                fish.DateAdded = DateTime.Now;
                _context.Add(fish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Title"] = "Create Fish";
            ViewData["Action"] = "Create";
            ViewData["TankId"] = new SelectList(_context.Tanks, "Id", "Name", fish.TankId);
            return View(fish);
        }

        // GET: Fish/Edit/5 — PRIVATE

        [Authorize]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var fish = await _context.Fish.FindAsync(id);
            if (fish == null) return NotFound();

            ViewData["Title"] = "Edit Fish";
            ViewData["Action"] = "Edit";
            ViewData["TankId"] = new SelectList(_context.Tanks, "Id", "Name", fish.TankId);
            return View(fish);
        }

        // POST: Fish/Edit/5 — PRIVATE

        [Authorize]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Fish fish)
        {
            if (id != fish.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishExists(fish.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["Title"] = "Edit Fish";
            ViewData["Action"] = "Edit";
            ViewData["TankId"] = new SelectList(_context.Tanks, "Id", "Name", fish.TankId);
            return View(fish);
        }

        // GET: Fish/Delete/5 — PRIVATE

        [Authorize]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var fish = await _context.Fish
                .Include(f => f.Tank)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (fish == null) return NotFound();

            return View(fish);
        }

        // POST: Fish/Delete/5 — PRIVATE

        [Authorize]

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fish = await _context.Fish.FindAsync(id);
            if (fish != null)
            {
                _context.Fish.Remove(fish);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FishExists(int id)
        {
            return _context.Fish.Any(e => e.Id == id);
        }
    }
}