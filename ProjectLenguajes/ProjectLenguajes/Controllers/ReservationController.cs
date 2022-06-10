using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLenguajes.Models.Data;
using ProjectLenguajes.Models.Domain;

namespace ProjectLenguajes.Controllers
{
    public class ReservationController : Controller
    {
        private ReservationDAO reservationDAO;
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;

        public ReservationController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        // GET: ReservationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: ParkingController/Create
        public IActionResult GetAllReservation()
        {
            try
            {
                reservationDAO = new ReservationDAO(_configuration);


                return Ok(reservationDAO.Get());
            }
            catch (Exception)
            {

                return Error();
            }


        }
        public IActionResult GetAllReservationByClient(int id)
        {
            try
            {
                reservationDAO = new ReservationDAO(_configuration);


                return Ok(reservationDAO.GetByClient(id));
            }
            catch (Exception)
            {

                return Error();
            }


        }
        public IActionResult GetReservationById(int id)
        {
            try
            {
                reservationDAO = new ReservationDAO(_configuration);


                return Ok(reservationDAO.GetById(id));
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

        public IActionResult InsertReservation([FromBody] Reservation reservation)
        {

            reservationDAO = new ReservationDAO(_configuration);

            int resultToReturn = reservationDAO.InsertReservation(reservation);
            return Ok(resultToReturn);

        }

        public IActionResult consultReservation([FromBody] Reservation reservation)
        {

            reservationDAO = new ReservationDAO(_configuration);

       ;
            return Ok(reservationDAO.consultReservation(reservation));

        }
        // POST: ReservationController/Create
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

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
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

        public ActionResult CancelReservationB(int id)
        {
            reservationDAO = new ReservationDAO(_configuration);


            return Ok(reservationDAO.CancelReservation(id));
        }

        // POST: ReservationController/Delete/5
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
