using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace SideTradeCA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly string _connectionString;

        public UsersController(IConfiguration configuration)
        {
            _connectionString = configuration["Postgres"];
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string[] candidates = connection.Query<string>("SELECT candidate_name FROM code_academy_all.active_candidates").ToArray();
                return candidates;
            }
        }
    }
}