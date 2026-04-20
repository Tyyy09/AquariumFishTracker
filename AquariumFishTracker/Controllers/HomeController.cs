using System.Diagnostics;
using AquariumFishTracker.Data;
using AquariumFishTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AquariumFishTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // Logic: Swapped to the unified ApplicationDbContext
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Dashboard
        public async Task<IActionResult> Index()
        {
            // Optimization: These are now executing against the unified Identity/App database
            ViewBag.TotalFish = await _context.Fish.CountAsync();
            ViewBag.TotalTanks = await _context.Tanks.CountAsync();

            ViewBag.AvgPH = await _context.Tanks.AnyAsync()
                ? await _context.Tanks.AverageAsync(t => t.PH)
                : 0;

            // Analysis: DateTime.Now in a query can prevent plan caching in some SQL versions.
            // Using a variable is more stable.
            var cleaningThreshold = DateTime.Now.AddDays(-14);
            ViewBag.TanksNeedingCleaning = await _context.Tanks
                .Where(t => t.LastCleanedDate == null || t.LastCleanedDate < cleaningThreshold)
                .CountAsync();

            return View();
        }

        public IActionResult Privacy() => View();
        public IActionResult About() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}