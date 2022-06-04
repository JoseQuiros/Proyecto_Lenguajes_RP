using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLenguajes.Models;
using ProjectLenguajes.Models.Data;
using ProjectLenguajes.Models.Domain;
using System.Diagnostics;

namespace ProjectLenguajes.Controllers
{
    public class ClientController : Controller
    {

        private readonly ILogger<ClientController> _logger;
        private readonly IConfiguration _configuration;
        ClientDAO clientDAO;

        public ClientController(ILogger<ClientController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public IActionResult InsertClient([FromBody] Client client)
        {
            clientDAO = new ClientDAO(_configuration);
            int resultToReturn = clientDAO.Insert(client);
            return Ok(resultToReturn);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
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


        public IActionResult UpdateClient([FromBody] Client client)
        {
            //TODO: handle exception appropriately and send meaningful message to the view
            clientDAO = new ClientDAO(_configuration);
            return Ok(clientDAO.UpdateClient(client));

        }

        public IActionResult GetClientById(int id)
        {
            clientDAO = new ClientDAO(_configuration);
            Client client = clientDAO.Get(id);

            return Ok(client);

        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        public IActionResult DeleteClientById(int id)
        {
            clientDAO = new ClientDAO(_configuration);
         

            return Ok(clientDAO.Delete(id));

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}