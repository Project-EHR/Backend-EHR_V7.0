﻿using EasyHouseRent.Models;
using EasyHouseRent.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyHouseRent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvertisementController : ControllerBase
    {
        BaseData db = new BaseData();
        Advertisement anuncios = new Advertisement();

        [HttpGet]
        public List<object> Get([FromQuery] Advertisement Ad)
        {
            string sql = $"SELECT * FROM anuncios";
            return db.ConvertDataTabletoString(sql);
        }

        [HttpGet("{id}")]
        public List<object> GetAd(int id)
        {
            string sql = $"SELECT * FROM anuncios WHERE idanuncio = '{id}'";
            return db.ConvertDataTabletoString(sql);
        }

        [HttpGet("AdUser")]
        public IEnumerable<Advertisement> GetAdUser([FromQuery] int idusuario)
        {
            string sql = $"SELECT a.* FROM anuncios a WHERE idusuario = {idusuario};";
            DataTable dt = db.getTable(sql);
            List<Advertisement> listAdUser = new List<Advertisement>();
            listAdUser = (from DataRow dr in dt.Rows
                          select new Advertisement()
                          {
                              idanuncio = Convert.ToInt32(dr["idanuncio"]),
                              idusuario = Convert.ToInt32(dr["idusuario"]),
                              titulo = dr["titulo"].ToString(),
                              direccion = dr["direccion"].ToString(),
                              descripcion = dr["descripcion"].ToString(),
                              modalidad = dr["modalidad"].ToString(),
                              zona = dr["zona"].ToString(),
                              edificacion = dr["edificacion"].ToString(),
                              habitaciones = Convert.ToInt32(dr["habitaciones"]),
                              garaje = dr["garaje"].ToString(),
                              precio = Convert.ToInt64(dr["precio"]),
                              fecha = dr["fecha"].ToString(),
                              url1 = dr["url1"].ToString(),
                              url2 = dr["url2"].ToString(),
                              url3 = dr["url3"].ToString(),
                              url4 = dr["url4"].ToString(),
                              estado = dr["estado"].ToString(),
                              ciudad = dr["ciudad"].ToString()

                          }).ToList();

            return listAdUser;
        }

        [HttpPost]
        public string Post([FromBody] Advertisement Ad)
        {
            string sql = "INSERT INTO anuncios (idusuario,titulo,direccion,descripcion,modalidad,zona,edificacion,habitaciones,garaje,precio,fecha,url1,url2,url3,url4,estado,ciudad) VALUES ('" + Ad.idusuario + "','" + Ad.titulo + "','" + Ad.direccion + "','" + Ad.descripcion + "','" + Ad.modalidad + "','" + Ad.zona + "','" + Ad.edificacion + "','" + Ad.habitaciones + "','" + Ad.garaje + "','" + Ad.precio + "','" + Ad.fecha + "','" + Ad.url1 + "','" + Ad.url2 + "','" + Ad.url3 + "','" + Ad.url4 + "', '" + Ad.estado + "','" + Ad.ciudad + "');";
            return db.executeSql(sql);
        }

        [HttpPut("{id}")]
        public string Put([FromBody] Advertisement ad)
        {
            string sql = "UPDATE anuncios SET titulo = '" + ad.titulo + "', direccion = '" + ad.direccion + "', descripcion = '" + ad.descripcion + "', direccion ='" + ad.direccion + "', modalidad ='" + ad.modalidad + "', zona ='" + ad.zona + "', edificacion ='" + ad.edificacion + "', habitaciones ='" + ad.habitaciones + "', garaje ='" + ad.garaje + "', precio ='" + ad.precio + "', fecha ='" + ad.fecha + "', url1 ='" + ad.url1 + "', url2 ='" + ad.url2 + "', url3 ='" + ad.url3 + "', url4 ='" + ad.url4 + "', estado ='" + ad.estado + "', ciudad = '" + ad.ciudad + "'  WHERE idanuncio = '" + ad.idanuncio + "'";
            return db.executeSql(sql);
        }

        [HttpDelete("DeleteAd")]
        public string Delete([FromQuery] Advertisement ad)
        {
            string sql = $"DELETE FROM anuncios WHERE idanuncio = {ad.idanuncio}";
            return db.executeSql(sql);
        }
    }
}
