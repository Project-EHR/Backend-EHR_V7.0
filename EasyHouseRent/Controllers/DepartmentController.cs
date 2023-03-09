using EasyHouseRent.Models.Entities;
using EasyHouseRent.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        BaseData db = new BaseData();
        Department departamento = new Department();

        [HttpGet]
        public List<object> Get()
        {
            string sql = "SELECT * FROM departamento WHERE nombre != 'desconocido'";
            return db.ConvertDataTabletoString(sql);
        }
    }
}
