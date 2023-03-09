using EasyHouseRent.Helpers;
using EasyHouseRent.Models;
using EasyHouseRent.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmationEmailController : ControllerBase
    {
        BaseData db = new BaseData();
        Users user = new Users();
        private readonly IConfiguration conf;
        public ConfirmationEmailController(IConfiguration config)
        {
            conf = config;
        }

        [HttpPost]
        public ActionResult<object> Post([FromQuery] Users user)
        {
            string sql = $"SELECT email FROM usuarios WHERE email = '{user.email}';";
            string secret = this.conf.GetValue<string>("Secret");
            var jwt = new JWT(secret);
            var token = jwt.CreateTokenEmail(db.executeSql(sql));
            return Ok(new { state = true, message = "Token For Created Email", token });
        }

        [HttpPost("/verifyEmail")]
        public bool PostEmail([FromQuery] string email)
        {
            string sql = $"SELECT email FROM usuarios where email = '{email}';";
            return user.ConfirmationEmail(sql);
        }
    }
}
