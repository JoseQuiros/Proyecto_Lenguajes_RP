using Microsoft.AspNetCore.Mvc;
using ProjectLenguajes.Models;
using ProjectLenguajes.Models.Data;
using ProjectLenguajes.Models.Domain;
using System.Diagnostics;

namespace ProjectLenguajes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        UserDAO userDAO;
        VehicleDAO vehicleDAO;

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Get()
        {
            userDAO = new UserDAO(_configuration);
            return Ok(userDAO.Get());

        }

        public IActionResult Insert([FromBody] User user)
        {

            userDAO = new UserDAO(_configuration);

            if (userDAO.Get(user.Email).Email == null)
            {

                int resultToReturn = userDAO.Insert(user);
                return Ok(resultToReturn);
            }
            else
            {
                return Error();
            }
        }
        public IActionResult InsertVehicle([FromBody] Vehicle vehicle)
        {

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


        //public IActionResult GetByEmail(string email)
        //{
        //    userDAO = new UserDAO(_configuration);
        //   // User user = UserDAO.Get(email);

        //    return Ok(user);

        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}