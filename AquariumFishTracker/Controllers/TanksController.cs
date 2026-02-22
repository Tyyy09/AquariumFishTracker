using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AquariumFishTracker.Data;
using AquariumFishTracker.Models;

namespace AquariumFishTracker.Controllers
{
    public class TanksController : Controller
    {
        private readonly AquariumContext _context;

        public TanksController(AquariumContext context)
        {
            _context = context;
        }

        // GET: Tanks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tanks.ToListAsync());
        }

        // GET: Tanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var tank = await _context.Tanks
                .Include(t => t.Fish) // show fish inside tank
                .FirstOrDefaultAsync(m => m.Id == id);

            if (tank == null) return NotFound();

            return View(tank);
        }

        // GET: Tanks/Create
        public IActionResult Create()
        {
            ViewData["Title"] = "Create Tank";
            ViewData["Action"] = "Create";

            return View();
        }

        // POST: Tanks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tank tank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Title"] = "Create Tank";
            ViewData["Action"] = "Create";

            return View(tank);
        }

        // GET: Tanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tank = await _context.Tanks.FindAsync(id);
            if (tank == null) return NotFound();

            ViewData["Title"] = "Edit Tank";
            ViewData["Action"] = "Edit";

            return View(tank);
        }

        // POST: Tanks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tank tank)
        {
            if (id != tank.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TankExists(tank.Id)) return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["Title"] = "Edit Tank";
            ViewData["Action"] = "Edit";

            return View(tank);
        }

        // GET: Tanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tank = await _context.Tanks
                .FirstOrDefaultAsync(m => m.Id == id);

            if (tank == null) return NotFound();

            return View(tank);
        }

        // POST: Tanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tank = await _context.Tanks.FindAsync(id);

            if (tank != null)
            {
                _context.Tanks.Remove(tank);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TankExists(int id)
        {
            return _context.Tanks.Any(e => e.Id == id);
        }
    }
}
