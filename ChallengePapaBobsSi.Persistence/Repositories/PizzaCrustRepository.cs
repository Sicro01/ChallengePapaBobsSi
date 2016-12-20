using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace ChallengePapaBobsSi.Persistence.Repositories
{
    public class PizzaCrustRepository
    {
        private static readonly IMapper Mapper = AutoMapperPersistenceConfiguration.MapperConfiguration.CreateMapper();
        public static DTOResult GetPizzaCrustsDTO()
        {
            DTOResult dtoResult = new DTOResult();
            try
            {
                ///1 - Create instance of the database
                PapaBobsPizzasWebAppEntityModel db = new PapaBobsPizzasWebAppEntityModel();
                //2 - Create instance of target table and convert to a List
                var dbPizzaCrusts = db.PizzaCrusts.ToList();
                //3 - Create list of target DTO objects
                var dtoPizzaCrusts = new List<DTO.PizzaCrustDTO>();
                //4 - Add each DAO to the DTO list
                foreach (var crust in dbPizzaCrusts)
                {
                    var dtoPizzaCrust = Mapper.Map<DTO.PizzaCrustDTO>(crust);
                    dtoPizzaCrusts.Add(dtoPizzaCrust);
                }
                dtoResult.Success = true;
                dtoResult.DynamicObject = dtoPizzaCrusts;
                return dtoResult;
            }
            catch (Exception ex)
            {
                dtoResult.Success = false;
                dtoResult.DynamicObject = ex;
                return dtoResult;
                //Logger.Instance.Error(result, this);
            }
        }
        public static void PizzaCrustDTOUpdateARow(DTO.PizzaCrustDTO pizzaCrustDTO)
        {
            //1 - Create instance of the database and add the new Customer Order
            PapaBobsPizzasWebAppEntityModel db = new PapaBobsPizzasWebAppEntityModel();
            try
            {
                var pizzaCrust = db.PizzaCrusts.SingleOrDefault(p => p.PizzaCrustId == pizzaCrustDTO.PizzaCrustId);
                pizzaCrust.PizzaCrustType = pizzaCrustDTO.PizzaCrustType;
                pizzaCrust.PizzaCrustPrice = pizzaCrustDTO.PizzaCrustPrice;
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
    }
}