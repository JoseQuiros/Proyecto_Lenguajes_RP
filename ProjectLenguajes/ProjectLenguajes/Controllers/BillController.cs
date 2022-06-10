using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectLenguajes.Models.Data;
using ProjectLenguajes.Models.Domain;

namespace ProjectLenguajes.Controllers
{
    public class BillController : Controller
    {
        private BillDAO billDAO;
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;

        public BillController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
    
            // GET: BillController
            public ActionResult Index()
            {
                return View();
            }

        public IActionResult GetBills()
        {
            try
            {
                billDAO = new BillDAO(_configuration);

                return Ok(billDAO.Get());
            }
            catch (Exception)
            {

                return Error();
            }


        }

        public IActionResult InsertBill([FromBody] Bill bill)
        {

            billDAO = new BillDAO(_configuration);

            int resultToReturn = billDAO.InsertBill(bill);
            return Ok(resultToReturn);

        }
        // GET: BillController/Details/5
        public ActionResult Details(int id)
            {
                return View();
            }

            // GET: BillController/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: BillController/Create
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

            // GET: BillController/Edit/5
            public ActionResult Edit(int id)
            {
                return View();
            }

            // POST: BillController/Edit/5
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

            // GET: BillController/Delete/5
            public ActionResult Delete(int id)
            {
                return View();
            }

            // POST: BillController/Delete/5
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

        private IActionResult Error()
        {
            throw new NotImplementedException();
        }
    }
}
