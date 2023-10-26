using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session5.DAL;
using Session5.Models;
using System.Data;
using System.Data.SqlClient;

namespace Session5.Controllers
{
    [Route("Services")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly SqlConnection _conn = Connection.GetConnection();

        [HttpGet]
        [Route("Types")]
        public IActionResult ListTypes()
        {
            string q = "EXECUTE usp_ListsServicesTypes";
            List<ServiceType> services = new();
            DataTable dt = new();
            try
            {
                new SqlDataAdapter(q, _conn).Fill(dt);
                foreach (DataRow item in dt.Rows)
                {   
                    services.Add(
                        new ServiceType
                        {
                            ID = int.Parse(item["ID"].ToString()),
                            Description = item["Description"].ToString(),
                            IconName = item["IconName"].ToString(),
                            Name = item["Name"].ToString()
                        }
                        );

                }
                return Ok(new Response<List<ServiceType>>("Lista de tipos de servicio", services));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<String>("Hubo un error al cargar los datos", ex.Message));
            }

        }


    }
}
