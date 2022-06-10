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

        public IActionResult InsertRol([FromBody] Rol rol)
        {
            // GET: UserController

            rolDAO = new RolDAO(_configuration);

            //if (vehicleDAO.Get(vehicle.Brand).Brand == null)
            //{

            int resultToReturn = rolDAO.Insert(rol);
            return Ok(resultToReturn);
            //}
            //else
            //{
            //    return Error();
            //}
        }
        public IActionResult GetRolById(int id)
        {
            RolDAO rolDAO = new RolDAO(_configuration);
            Rol rol = rolDAO.Get(id);

            return Ok(rol);

        }

        public IActionResult DeleteRol(int id)
        {
            rolDAO = new RolDAO(_configuration);

            return Ok(rolDAO.Delete(id));

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



        public IActionResult UpdateRol([FromBody] Rol rol)
        {
            //TODO: handle exception appropriately and send meaningful message to the view
            rolDAO = new RolDAO(_configuration);
            return Ok(rolDAO.UpdateRol(rol));

        }







        private IActionResult Error()
        {
            throw new NotImplementedException();
        }



    }
}
