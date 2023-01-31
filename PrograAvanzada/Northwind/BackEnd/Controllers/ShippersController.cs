using BackEnd.DAL;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc; // For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860 
namespace BackEnd.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private IShippersDAL shippersDAL;



        #region Constructor
        public ShippersController()
        {
            shippersDAL = new ShippersDALImpl(new Entities.Entities.NorthWindContext());
        }
        #endregion       


        #region Consultar
        // GET: api/<ShippersController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Shipper> shippers = shippersDAL.GetAll();
            return new JsonResult(shippers);
        }         // GET api/<ShippersController>/5


        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Shipper shippers;
            shippers = shippersDAL.Get(id);
            return new JsonResult(shippers);
        }
        #endregion


        #region Agregar
        // POST api/<ShippersController>
        [HttpPost]
        public JsonResult Post([FromBody] Shipper shippers)
        {
            shippersDAL.Add(shippers);
            return new JsonResult(shippers);
        }
        #endregion

        #region Modificar
        // PUT api/<ShippersController>/5
        [HttpPut]
        public JsonResult Put([FromBody] Shipper shippers)
        {
            shippersDAL.Update(shippers);
            return new JsonResult(shippers);
        }
        #endregion


        #region Eliminar
        // DELETE api/<ShippersController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Shipper shipper = new Shipper { ShipperId = id };
            shippersDAL.Remove(shipper); return new JsonResult(shipper);
        }
        #endregion
    }
}