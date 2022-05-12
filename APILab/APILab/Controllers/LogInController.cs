#nullable disable
using APILab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class LogInController : ControllerBase
    {
        private readonly Project_BBBContext _context;

        public LogInController()
        {
            _context = new Project_BBBContext();
        }

        [HttpGet("{email},{password}")]
        //public async Task<ActionResult<Rol>> LogIn(string email, string password)
        //{
        //    var param = new SqlParameter(email, password);
        //    var rol = 

        //    if (rol == null)
        //    {
        //        return NotFound();
        //    }

        //    return rol;
        //}
        // GET: api/Students/5
        //[HttpGet("GetStudentEmail/{email},{id}")]
        public async Task<ActionResult<Rol>> GetStudentEmail(string email, string password)
        {
            var rols = _context.Rols
                                    .FromSqlInterpolated($@"EXEC LogIn @Email={email}, @Password={password}")
                                    .AsAsyncEnumerable();
            await foreach (var rol in rols)
            {
                return rol;
            }
            return NotFound();
        }




    }
}
