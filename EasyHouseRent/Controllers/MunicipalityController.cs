using EasyHouseRent.Models;
using EasyHouseRent.Models.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : ControllerBase
    {
        BaseData db = new BaseData();
        Municipality municipios = new Municipality();

        [HttpGet]
        public List<object> Get()
        {
            string sql = "SELECT * FROM municipios WHERE nombre != 'desconocido'";
            return db.ConvertDataTabletoString(sql);
        }

        [HttpGet("{iddepartamento}")]
        public List<object> Get([FromQuery] int iddepartamento)
        {
            string sql = $"select m.* FROM municipios m INNER JOIN departamento d on m.departamento=d.iddepartamento where d.iddepartamento = {iddepartamento}";
            return db.ConvertDataTabletoString(sql);
        }
    }
}
