
using Microsoft.AspNetCore.Mvc;
using ProjectLenguajes.Models.Data;
using ProjectLenguajes.Models.Domain;

namespace ProjectLenguajes.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
        UserDAO userDAO;

        public UserController(ILogger<UserController> logger, IConfiguration configuration, UserDAO userDAO)
        {
            _logger = logger;
            _configuration = configuration;
           
        }
<<<<<<< Updated upstream
=======


        public IActionResult Login(string email, string password)
        {
            userDAO = new UserDAO(_configuration);
            User user = userDAO.Get(email);
            if (user.Email == null)
            {
                if (user.Password == password)
                {

                    return Json("Authenticated");

                }
                else
                {

                    return Json("Incorrect");

                }

            }
            else {
                return Json("Failed");

            }
                 

        }

>>>>>>> Stashed changes
        public IActionResult GetByEmail(string email)
        {
            userDAO = new UserDAO(_configuration);
            return Ok(userDAO.Get(email));

        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
