using EasyHouseRent.Models;
using EasyHouseRent.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StructureController : ControllerBase
    {
        BaseData db = new BaseData();

        [HttpGet("AboutUs")]
        public IEnumerable<Advertisement> GetImagesAds()
        {
            string sql = $"SELECT url1 FROM anuncios LIMIT 8;";
            DataTable dt = db.getTable(sql);
            List<Advertisement> listImagesAds = new List<Advertisement>();
            listImagesAds = (from DataRow dr in dt.Rows
                             select new Advertisement()
                             {
                                 url1 = dr["url1"].ToString(),

                             }).ToList();

            return listImagesAds;

        }
    }
}
