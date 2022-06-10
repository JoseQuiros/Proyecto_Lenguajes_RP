using Microsoft.AspNetCore.Mvc;
using ProjectLenguajes.Models;
using ProjectLenguajes.Models.Data;
using ProjectLenguajes.Models.Domain;
using System.Diagnostics;

namespace ProjectLenguajes.Controllers
{

    public class RolController : Controller

    {
        private readonly ILogger<RolController> _logger;
        private RolDAO rolDAO;
        private IConfiguration _configuration;

        public RolController(ILogger<RolController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        // GET: RolController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RolController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolController/Create
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

        public IActionResult GetRols()
        {
            try
            {
                rolDAO = new RolDAO(_configuration);

                return Ok(rolDAO.GetRols());
            }
            catch (Exception)
            {

                return Error();
            }

        }



        public IActionResult GetRolsById(int id)
        {
            try
            {
                rolDAO = new RolDAO(_configuration);

                return Ok(rolDAO.GetRols(id));
            }
            catch (Exception)
            {

                return Error();
            }

        }

        private IActionResult Error()
        {
            throw new NotImplementedException();
        }




        // GET: RolController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RolController/Edit/5
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

        // GET: RolController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RolController/Delete/5
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
    }
}
