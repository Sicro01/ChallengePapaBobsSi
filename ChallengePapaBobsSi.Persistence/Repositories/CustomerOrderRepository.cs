using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace ChallengePapaBobsSi.Persistence.Repositories
{
    public class CustomerOrderRepository
    {
        private static readonly IMapper Mapper = AutoMapperPersistenceConfiguration.MapperConfiguration.CreateMapper();
        public static DTOResult GetCustomerOrdersDTO()
        {
            DTOResult dtoResult = new DTOResult();
            try
            {
                //1 - Create instance of the database
                PapaBobsPizzasWebAppEntityModel db = new PapaBobsPizzasWebAppEntityModel();
                //2 - Create instance of target table and convert to a List
                var dbCustomerOrders = db.CustomerOrders.ToList();
                //3 - Create list of target DTO objects
                var dtoCustomerOrders = new List<DTO.CustomerOrderDTO>();
                //4 - Add each DAO to the DTO list
                foreach (var customerorder in dbCustomerOrders)
                {
                    var dtoCustomerOrder = Mapper.Map<DTO.CustomerOrderDTO>(customerorder);
                    if (customerorder.CustomerOrderComplete == 0)
                    {
                        dtoCustomerOrders.Add(dtoCustomerOrder);
                    }
                }
                dtoResult.Success = true;
                dtoResult.DynamicObject = dtoCustomerOrders;
                return dtoResult;
            }
            catch (Exception ex)
            {
                dtoResult.Success = false;
                dtoResult.DynamicObject = ex;
                return dtoResult;
            }
        }
        public static void CustomerDTOAddARow(DTO.CustomerOrderDTO customerOrderDTO)
        {
            //1 - Convert the DTO object into the DB object
            var customerOrder = Mapper.Map<CustomerOrder>(customerOrderDTO);
            //2 - Create instance of the database and add the new Customer Order
            PapaBobsPizzasWebAppEntityModel db = new PapaBobsPizzasWebAppEntityModel();
            try
            {
                db.Database.Connection.Open();
                db.CustomerOrders.Add(customerOrder);
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
        }
        public static void CustomerDTOUpdateARow(Guid customerOrderId, int customerOrderComplete)
        {
            //1 - Create instance of the database and add the new Customer Order
            PapaBobsPizzasWebAppEntityModel db = new PapaBobsPizzasWebAppEntityModel();
            try
            {
                var customerOrder = db.CustomerOrders.SingleOrDefault(p => p.CustomerOrderId == customerOrderId);
                customerOrder.CustomerOrderComplete = customerOrderComplete;
                db.SaveChanges();

                //db.Database.Connection.Open();
                //db.CustomerOrders.Attach(customerOrder);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}