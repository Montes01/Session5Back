using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session5.DAL;
using Session5.Models;
using System.Data;
using System.Data.SqlClient;

namespace Session5.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly static SqlConnection _conn = Connection.GetConnection();


        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody]BasicUser user)
        {
            string q = $"EXECUTE usp_Login '{user.username}', '{user.password}'";
            _conn.Open();
            try
            {
                DataTable dt = new();
                new SqlDataAdapter(q, _conn).Fill(dt);

                if (dt.Rows.Count < 1) return Unauthorized(new Response<object>("No existee el usuario", null));

                User usuario = new()
                {
                    id = int.Parse(dt.Rows[0]["ID"].ToString()),
                    userTypeId = int.Parse(dt.Rows[0]["UserTypeId"].ToString()),
                    birthDate = dt.Rows[0]["BirthDate"].ToString(),
                    familyCount = int.Parse(dt.Rows[0]["FamilyCount"].ToString()),
                    fullName = dt.Rows[0]["FullName"].ToString(),
                    gender = (bool)dt.Rows[0]["Gender"],
                    password = dt.Rows[0]["Password"].ToString(),
                    username = dt.Rows[0]["UserName"].ToString(),
                };
                 
                return Ok(new Response<User>("Correctamente Loggeado", usuario));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<object>(ex.Message, null));
            } finally
            {
                _conn.Close();
            }



        }




    }
}
