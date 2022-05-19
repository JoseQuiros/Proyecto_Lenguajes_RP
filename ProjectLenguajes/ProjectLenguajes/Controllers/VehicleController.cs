using Microsoft.AspNetCore.Mvc;
using ProjectLenguajes.Models.Data;
using ProjectLenguajes.Models.Domain;

namespace ProjectLenguajes.Controllers
{
    public class VehicleController

    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IConfiguration _configuration;
        VehicleDAO vehicleDAO;

        public VehicleController(ILogger<VehicleController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IActionResult InsertVehicle([FromBody] Vehicle vehicle)
        {
             // GET: UserController
       
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


        private IActionResult Ok(int resultToReturn)
        {
            throw new NotImplementedException();
        }
    }
}
