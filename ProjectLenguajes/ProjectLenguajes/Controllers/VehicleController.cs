using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLenguajes.Models.Data;
using ProjectLenguajes.Models.Domain;

namespace ProjectLenguajes.Controllers
{
    public class VehicleController : Controller
    {

        private readonly ILogger<VehicleController> _logger;
        private readonly IConfiguration _configuration;
        VehicleDAO vehicleDAO;

        public VehicleController(ILogger<VehicleController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IActionResult InsertVehicle([FromBody] Vehicle vehicle)
        {
            // GET: UserController

            vehicleDAO = new VehicleDAO(_configuration);

            //if (vehicleDAO.Get(vehicle.Brand).Brand == null)
            //{

            int resultToReturn = vehicleDAO.Insert(vehicle);
            return Ok(resultToReturn);
            //}
            //else
            //{
            //    return Error();
            //}
        }
        // GET: VehiclesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VehiclesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehiclesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehiclesController/Create
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

        // GET: VehiclesController/Edit/5
        public IActionResult UpdateVehicle([FromBody] Vehicle vehicle)
        {
            //TODO: handle exception appropriately and send meaningful message to the view
            vehicleDAO = new VehicleDAO(_configuration);
            return Ok(vehicleDAO.Update(vehicle));

        }


        // POST: VehiclesController/Edit/5
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
        public IActionResult DeleteVehicleById(int id)
        {
            vehicleDAO = new VehicleDAO(_configuration);
            return Ok(vehicleDAO.Delete(id));

        }

        public IActionResult GetVehicleById(int id)
        {
            vehicleDAO = new VehicleDAO(_configuration);
            Vehicle vehicle = vehicleDAO.Get(id);

            return Ok(vehicle);

        }

    }
}


