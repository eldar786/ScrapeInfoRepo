using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScrapeInfoTask.Models;

namespace ScrapeInfoTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        TestContext _context = new TestContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var listOfData = _context.ScrapeInfos.ToList();
            return View(listOfData);
        }

        [HttpPost]
        public ActionResult Index(DateTime dtFrom, DateTime dtTo)
        {
            ViewBag.DateFrom = dtFrom;
            ViewBag.DateTo = dtTo;

            var listOfDataByDate = _context.ScrapeInfos.
            Where(s => s.DateTime >= dtFrom && s.DateTime <= dtTo).ToList();

            return View(listOfDataByDate);

        }

        public IActionResult Converter()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Delete(int id)
        {
            var data = _context.ScrapeInfos.Where(s => s.Id == id).FirstOrDefault();
            _context.ScrapeInfos.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
