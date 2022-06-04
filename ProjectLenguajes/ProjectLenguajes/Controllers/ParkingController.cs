using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLenguajes.Models;
using ProjectLenguajes.Models.Data;
using ProjectLenguajes.Models.Domain;
using System.Diagnostics;

namespace ProjectLenguajes.Controllers
{

    public class ParkingController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ParkingDAO parkingDAO;
        private IConfiguration _configuration;

        public ParkingController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        // GET: ParkingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ParkingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParkingController/Create
        public IActionResult GetAllParkings()
        {
            try
            {
                parkingDAO = new ParkingDAO(_configuration);

                return Ok(parkingDAO.Get());
            }
            catch (Exception)
            {

                return Error();
            }

        }

        public IActionResult InsertParking([FromBody] Parking parking)
        {

            parkingDAO = new ParkingDAO(_configuration);

            int resultToReturn = parkingDAO.InsertParking(parking);
            return Ok(resultToReturn);
        
        }
        // POST: ParkingController/Create
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

        // GET: ParkingController/Edit/5
        public IActionResult GetParkingById(int id)
        {
            ParkingDAO parkingDAO = new ParkingDAO(_configuration);
            Parking parking = parkingDAO.Get(id);

            return Ok(parking);

        }

        // POST: ParkingController/Edit/5
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

        public IActionResult UpdateParking([FromBody] Parking parking)
        {
            //TODO: handle exception appropriately and send meaningful message to the view
            parkingDAO = new ParkingDAO(_configuration);
            return Ok(parkingDAO.UpdateParking(parking));

        }

       public IActionResult DeleteParking(int id)
        {
            parkingDAO = new ParkingDAO(_configuration);

            return Ok(parkingDAO.Delete(id));

        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
