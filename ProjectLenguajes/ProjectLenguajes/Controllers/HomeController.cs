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
        ClientDAO clientDAO;

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult IndexOperator()
        {
            return View();
        }

        public IActionResult IndexAdmin()
        {
            return View();
        }
        public IActionResult IndexClient()
        {
            return View();
        }


        public IActionResult GetAllUsers()
        {
            userDAO = new UserDAO(_configuration);
            return Ok(userDAO.Get());

        }

        public IActionResult GetAllVehicles()
        {
            vehicleDAO = new VehicleDAO(_configuration);
            return Ok(vehicleDAO.Get());

        }

        public IActionResult GetAllClients()
        {
            clientDAO = new ClientDAO(_configuration);
            return Ok(clientDAO.Get());

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

        public IActionResult Login([FromBody] User user)
        {

            userDAO = new UserDAO(_configuration);
            User user1 = userDAO.Get(user.Email);
            if (user1.Email != null)
            {
                if (user1.Password == user.Password)
                {
                   switch(user1.IdRol)
                    {
                            case  1:
                            HttpContext.Session.SetString("UserRol", user1.IdRol.ToString());
                            HttpContext.Session.SetString("UserEmail", user1.Email);
                            HttpContext.Session.SetString("UserName", user1.Name);

                            return Json(new { result = "Redirect", url = Url.Action("IndexClient", "Home") });

                            case 2:
                            HttpContext.Session.SetString("UserRol", user1.IdRol.ToString());
                            HttpContext.Session.SetString("UserEmail", user1.Email);
                            HttpContext.Session.SetString("UserName", user1.Name);

                            return Json(new { result = "Redirect", url = Url.Action("IndexOperator", "Home") });
                           

                            case 3:
                            HttpContext.Session.SetString("UserRol", user1.IdRol.ToString());
                            HttpContext.Session.SetString("UserEmail", user1.Email);
                            HttpContext.Session.SetString("UserName", user1.Name);

                            return Json(new { result = "Redirect", url = Url.Action("IndexAdmin", "Home") });

                    }
                    return Json(new { result = "Redirect", url = Url.Action("Index", "Home") });
                }
                else
                {
                    return Json("Incorrect");
                }
            }
            else
            {
                return Json("Failed");
            }

        }

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