using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SideTradeCA.WebApi.Entities;

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
        public ActionResult<IEnumerable<ActiveCandidate>> Get()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                ActiveCandidate[] candidates = connection.Query<ActiveCandidate>("SELECT * FROM code_academy_all.vw_get_all_users").ToArray();
                return candidates;
            }
        }
    }
}