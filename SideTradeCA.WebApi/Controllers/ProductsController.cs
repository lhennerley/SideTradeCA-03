using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SideTradeCA.WebApi.Entities;

namespace SideTradeCA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly string _connectionString;

        public ProductsController()
        {
            _connectionString = "Server=54.194.176.170;Port=5432;Database=code_academy_candidate_3;UserId=candidate_3;Password=k%w!xM4#QmEr;";
        }

        public async Task<IEnumerable<Product>> Get()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Product>("SELECT * FROM ca_project.vw_products");
            }
        }
    }
}