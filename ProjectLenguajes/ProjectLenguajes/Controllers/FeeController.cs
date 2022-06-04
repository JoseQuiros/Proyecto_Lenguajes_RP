using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLenguajes.Models;
using ProjectLenguajes.Models.Data;
using ProjectLenguajes.Models.Domain;
using System.Diagnostics;

namespace ProjectLenguajes.Controllers
{
    public class FeeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private FeeDAO feeDAO;
        private IConfiguration _configuration;

        public FeeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        // GET: FeeController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllFees()
        {
            try
            {
                feeDAO = new FeeDAO(_configuration);

                return Ok(feeDAO.Get());
            }
            catch (Exception)
            {

                return Error();
            }

        }

        // GET: FeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        public IActionResult InsertFee([FromBody] Fee fee)
        {

            feeDAO = new FeeDAO(_configuration);

            int resultToReturn = feeDAO.InsertFee(fee);
            return Ok(resultToReturn);

        }

        // POST: FeeController/Create
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

        public IActionResult GetFeeById(int id)
        {
            FeeDAO feeDAO = new FeeDAO(_configuration);
            Fee fee = feeDAO.Get(id);

            return Ok(fee);

        }

        // GET: FeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult UpdateFee([FromBody] Fee fee)
        {
            //TODO: handle exception appropriately and send meaningful message to the view
            feeDAO = new FeeDAO(_configuration);
            return Ok(feeDAO.UpdateFee(fee));

        }

        // POST: FeeController/Edit/5
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

        // GET: FeeController/Delete/5
        public IActionResult DeleteFeeById(int id)
        {
            feeDAO = new FeeDAO(_configuration);

            return Ok(feeDAO.Delete(id));

        }

        // POST: FeeController/Delete/5
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
