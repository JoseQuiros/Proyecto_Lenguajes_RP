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
        public async Task<ActionResult<User>> LogIn(string email, string password)
        {
            var logs = _context.Users
                                    .FromSqlInterpolated($@"EXEC LogIn @Email={email}, @Password={password}")
                                    .AsAsyncEnumerable();
            await foreach (var log in logs)
            {
                return log;
            }
            return NotFound();
        }
    }
}
