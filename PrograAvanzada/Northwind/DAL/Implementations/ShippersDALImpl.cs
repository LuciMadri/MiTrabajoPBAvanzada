using DAL;
using DAL.Implementations;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class ShippersDALImpl : IShippersDAL
    {
        NorthWindContext context;

        public ShippersDALImpl()
        {
            context = new NorthWindContext();

        }

        public ShippersDALImpl(NorthWindContext northWindContext)
        {
            this.context = northWindContext;
        }



        public bool Add(Shipper entity)
        {
            try
            {


                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shipper> Find(Expression<Func<Shipper, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Shipper Get(int ShipperId)
        {
            try
            {
                Shipper shipper;
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    shipper = unidad.genericDAL.Get(ShipperId);
                }
                return shipper;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Shipper> Get()
        {
            try
            {
                IEnumerable<Shipper> shippers;
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    shippers = unidad.genericDAL.GetAll();
                }
                return shippers.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }



        public IEnumerable<Shipper> GetAll()
        {
            try
            {
                IEnumerable<Shipper> shippers;
                using (UnidadDeTrabajo<Shipper> unidad = new UnidadDeTrabajo<Shipper>(context))
                {
                    shippers = unidad.genericDAL.GetAll();
                }
                return shippers;
            }
            catch (Exception)
            {

                throw;
            }
        }


       


        public bool Remove(Shipper entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Shipper> entities)
        {
            throw new NotImplementedException();
        }

        public Shipper SingleOrDefault(Expression<Func<Shipper, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shipper entity)
        {
            throw new NotImplementedException();
        }
    }
}
