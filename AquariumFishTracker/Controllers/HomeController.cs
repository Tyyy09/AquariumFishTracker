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
        private readonly AquariumContext _context;

        public HomeController(ILogger<HomeController> logger, AquariumContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Dashboard
        public async Task<IActionResult> Index()
        {
            ViewBag.TotalFish = await _context.Fish.CountAsync();
            ViewBag.TotalTanks = await _context.Tanks.CountAsync();

            ViewBag.AvgPH = await _context.Tanks.AnyAsync()
                ? await _context.Tanks.AverageAsync(t => t.PH)
                : 0;

            ViewBag.TanksNeedingCleaning = await _context.Tanks
                .Where(t => t.LastCleanedDate == null || t.LastCleanedDate < DateTime.Now.AddDays(-14))
                .CountAsync();

            return View();
        }

        // Static pages
        public IActionResult Privacy() => View();
        public IActionResult About() => View();

        // Error handler
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
