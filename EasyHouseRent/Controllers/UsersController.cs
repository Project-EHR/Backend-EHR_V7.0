using EasyHouseRent.Models;
using EasyHouseRent.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        BaseData db = new BaseData();

        [HttpGet("GetUser")]
        public IEnumerable<Users> GetUser([FromQuery] int idusuario)
        {
            string sql = $"SELECT u.idusuario,u.nombre,u.apellidos,u.email,u.telefono,u.foto,d.nombre AS depnombre,m.nombre AS munnombre FROM departamento d INNER JOIN usuarios u ON d.iddepartamento = u.departamento INNER JOIN municipios m ON u.municipio = m.idmunicipio  WHERE idusuario = {idusuario};";
            DataTable dt = db.getTable(sql);
            List<Users> userList = new List<Users>();
            List<Municipality> munList = new List<Municipality>();
            List<Department> depList = new List<Department>();

            munList = (from DataRow dr in dt.Rows
                       select new Municipality()
                       {
                           nombre = dr["munnombre"].ToString()

                       }).ToList();

            depList = (from DataRow dr in dt.Rows
                       select new Department()
                       {
                           nombre = dr["depnombre"].ToString()
                       }).ToList();

            userList = (from DataRow dr in dt.Rows
                        select new Users()
                        {
                            idusuario = Convert.ToInt32(dr["idusuario"]),
                            nombre = dr["nombre"].ToString(),
                            apellidos = dr["apellidos"].ToString(),
                            telefono = dr["telefono"].ToString(),
                            email = dr["email"].ToString(),
                            foto = dr["foto"].ToString(),
                            listDepartment = depList,
                            listMunicipality = munList

                        }).ToList();

            return userList;
        }

        [HttpPost]
        public string Post([FromBody] Users user)
        {
            string sql = "INSERT INTO usuarios (nombre,apellidos,edad,telefono,email,contraseña,estado,departamento,municipio, foto) VALUES ('" + user.nombre + "','" + user.apellidos + "','" + user.edad + "','" + user.telefono + "','" + user.email + "','" + user.contrasenna + "','" + user.estado + "','" + user.departamento + "','" + user.municipio + "','" + user.foto + "' );";
            return db.executeSql(sql);
        }

        [HttpPut]
        public string Put([FromBody] Users user)
        {
            string sql = "UPDATE usuarios SET nombre = '" + user.nombre + "', apellidos = '" + user.apellidos + "', edad = '" + user.edad + "', telefono ='" + user.telefono + "', email ='" + user.email + "'  WHERE idusuario = '" + user.idusuario + "';";
            return db.executeSql(sql);
        }

        [HttpPost("ProfilePicture")]
        public string PutProfilePicture([FromBody] Users user)
        {
            string sql = $"UPDATE usuarios SET foto = '{user.foto}' WHERE idusuario = {user.idusuario}";
            return db.executeSql(sql);
        }

        [HttpDelete]
        public string Delete([FromBody] Users user)
        {
            string sql = "DELETE FROM usuarios WHERE idusuario = " + user.idusuario;
            return db.executeSql(sql);
        }
    }
}
