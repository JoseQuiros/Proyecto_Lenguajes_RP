using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLenguajes.Models;
using ProjectLenguajes.Models.Data;
using System.Diagnostics;

namespace ProjectLenguajes.Controllers
{
    public class TypeVehicleController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        TypeVehicleDAO typeDAO;

        public TypeVehicleController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        // GET: TypeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        public IActionResult Get()
        {
            try
            {
                typeDAO = new TypeVehicleDAO(_configuration);

                return Ok(typeDAO.Get());
            }
            catch (Exception)
            {

                return Error();
            }

        }

        // POST: TypeController/Create
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

        // GET: TypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TypeController/Edit/5
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

        // GET: TypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TypeController/Delete/5
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
