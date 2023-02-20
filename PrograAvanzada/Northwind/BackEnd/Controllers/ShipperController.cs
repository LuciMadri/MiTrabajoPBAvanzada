using BackEnd.DAL;
using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersConroller : ControllerBase
    {

        private IShippersDAL shippersDAL;

        #region Convertir
        private ShippersModel Convertir(Shipper entity)
        {
            return new ShippersModel
            {
                ShipperId = entity.ShipperId,
                CompanyName = entity.CompanyName,
                Phone = entity.Phone

            };
        }


        private Shipper Convertir(ShippersModel model)
        {
            return new Shipper
            {
                ShipperId = model.ShipperId,
                CompanyName = model.CompanyName,
                Phone = model.Phone

            };
        }
        #endregion

        #region Constructor
        public ShippersConroller()
        {
            shippersDAL = new ShippersDALImpl(new Entities.Entities.NorthWindContext());

        }
        #endregion

        #region Consultar
        // GET: api/<CategoryController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Shipper> shippers = shippersDAL.GetAll();

            List <ShippersModel> lista = new List<ShippersModel>();

            foreach (var shipper in shippers)
            {
                lista.Add(Convertir(shipper));
            }
            return new JsonResult(lista);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Shipper shipper;
            shipper = shippersDAL.Get(id);

            return new JsonResult(Convertir(shipper));

        }
        #endregion

        #region Agregar
        // POST api/<ShipperController>
        [HttpPost]
        public JsonResult Post([FromBody] ShippersModel shipper)
        {

            Shipper entity = Convertir(shipper);
            shippersDAL.Add(entity);
            return new JsonResult(Convertir(shipper));

        }

        #endregion

        #region Modificar
        // PUT api/<CategoryController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ShippersModel shipper)
        {

            shippersDAL.Update(Convertir(shipper));
            return new JsonResult(Convertir(shipper));

        }
        #endregion

        #region Eliminar
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Shipper shipper = new Shipper { ShipperId = id };
            shippersDAL.Remove(shipper);

            return new JsonResult(Convertir(shipper));


        }


        #endregion
    }
}
