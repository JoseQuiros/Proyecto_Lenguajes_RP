using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLenguajes.Models;
using ProjectLenguajes.Models.Data;
using System.Diagnostics;

namespace ProjectLenguajes.Controllers
{
    public class TimeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        TimeDAO timeDAO;
        // GET: TimeController1

        public TimeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: TimeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TimeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        public IActionResult Get()
        {
            try
            {
                timeDAO = new TimeDAO(_configuration);

                return Ok(timeDAO.Get());
            }
            catch (Exception)
            {

                return Error();
            }

        }

        // POST: TimeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TimeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TimeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
