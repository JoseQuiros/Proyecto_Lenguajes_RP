using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLenguajes.Models;
using ProjectLenguajes.Models.Data;
using ProjectLenguajes.Models.Domain;
using System.Diagnostics;

namespace ProjectLenguajes.Controllers
{

    public class ParkingSlotController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ParkingSlotDAO parkingSlotDAO;
        private IConfiguration _configuration;

        public ParkingSlotController(ILogger<HomeController> logger, IConfiguration configuration)
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
        public IActionResult GetAllParkingSlot()
        {
            try
            {
                parkingSlotDAO = new ParkingSlotDAO(_configuration);

                return Ok(parkingSlotDAO.Get());
            }
            catch (Exception)
            {

                return Error();
            }

        }

        public IActionResult InsertParkingSlot([FromBody] ParkingSlot parkingSlot)
        {

            parkingSlotDAO = new ParkingSlotDAO(_configuration);

            int resultToReturn = parkingSlotDAO.InsertParkingSlot(parkingSlot);
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
        public IActionResult GetParkingSlotById(int id)
        {
            ParkingSlotDAO parkingSlotDAO = new ParkingSlotDAO(_configuration);
            ParkingSlot parkingSlot = parkingSlotDAO.Get(id);

            return Ok(parkingSlot);

        }  // GET: ParkingController/Edit/5
        public IActionResult GetParkingSlotByParking(int id)
        {
            parkingSlotDAO = new ParkingSlotDAO(_configuration);

            return Ok(parkingSlotDAO.GetSlotsByParking(id));
         

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

        public IActionResult UpdateParkingSlot([FromBody] ParkingSlot parkingSlot)
        {
            //TODO: handle exception appropriately and send meaningful message to the view
            parkingSlotDAO = new ParkingSlotDAO(_configuration);
            return Ok(parkingSlotDAO.UpdateParkingSlot(parkingSlot));

        }

        // GET: ParkingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParkingController/Delete/5
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
