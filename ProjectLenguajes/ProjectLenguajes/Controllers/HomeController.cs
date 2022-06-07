using Microsoft.AspNetCore.Mvc;
using ProjectLenguajes.Models;
using ProjectLenguajes.Models.Data;
using ProjectLenguajes.Models.Domain;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

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
                return Json("ITSREGIS");
            }
        }
        public IActionResult InsertVehicle([FromBody] Vehicle vehicle)
        {

            vehicleDAO = new VehicleDAO(_configuration);

            

                int resultToReturn = vehicleDAO.Insert(vehicle);
                return Ok(resultToReturn);
          
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
                            return Json(new { result = "Redirect", url = Url.Action("IndexClient", "Home"), user = user1 });

                            case 2:                         
                            return Json(new { result = "Redirect", url = Url.Action("IndexOperator", "Home"), user = user1 });
                        
                            case 3:
                                               
                            return Json(new { result = "Redirect", url = Url.Action("IndexAdmin", "Home"),user=user1 });

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
        /// USER
        /// 


        public IActionResult Logout()
        {
                    return Json(new { result = "Redirect", url = Url.Action("Index", "Home") });
        

        }
        /// USER
        /// 


        public IActionResult GetUserById(int id)
        {
            userDAO = new UserDAO(_configuration);
            User user = userDAO.Get(id);

            return Ok(user);

        }
        public IActionResult UpdateUser([FromBody] User user)
        {
            //TODO: handle exception appropriately and send meaningful message to the view
            userDAO = new UserDAO(_configuration);
            return Ok(userDAO.Update(user));

        }
        public IActionResult DeleteUserById(int id)
        {
            userDAO = new UserDAO(_configuration);
      

            return Ok(userDAO.Delete(id));

        }

        /// USER
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public int SendEmailAsync()
        {
            try
            {
                // Credentials
                var credentials = new NetworkCredential("pablo1140395@gmail.com", "contrasea");
                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress("pity14395@gmail.com", "Parking Slot"),
                    Subject = "TITULO DEL CORREO",
                    Body = "MENSAJE",
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress("pity14395@gmail.com"));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 25,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "YOUR SMTP SERVER",
                    EnableSsl = false,
                    Credentials = credentials
                };

                // Send it...         
                client.Send(mail);
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }

            return 1;
        }


    }
}

