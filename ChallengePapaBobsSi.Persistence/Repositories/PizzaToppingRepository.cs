using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace ChallengePapaBobsSi.Persistence.Repositories
{
    public class PizzaToppingRepository
    {
        private static readonly IMapper Mapper = AutoMapperPersistenceConfiguration.MapperConfiguration.CreateMapper();
        public static DTOResult GetPizzaToppingsDTO()
        {
            DTOResult dtoResult = new DTOResult();
            try
            {
                //1 - Create instance of the database
                PapaBobsPizzasWebAppEntityModel db = new PapaBobsPizzasWebAppEntityModel();
                //2 - Create instance of target table and convert to a List
                var dbPizzaToppings = db.PizzaToppings.ToList();
                //3 - Create list of target DTO objects
                var dtoPizzaToppings = new List<DTO.PizzaToppingDTO>();
                //4 - Add each DAO to the DTO list
                foreach (var pizzatopping in dbPizzaToppings)
                {
                    var dtoPizzaTopping = Mapper.Map<DTO.PizzaToppingDTO>(pizzatopping);
                    dtoPizzaToppings.Add(dtoPizzaTopping);
                }
                dtoResult.Success = true;
                dtoResult.DynamicObject = dtoPizzaToppings;
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

        public static void PizzaToppingDTOUpdateARow(DTO.PizzaToppingDTO pizzaToppingDTO)
        {
            //1 - Create instance of the database and add the new Customer Order
            PapaBobsPizzasWebAppEntityModel db = new PapaBobsPizzasWebAppEntityModel();
            try
            {
                var pizzaTopping = db.PizzaToppings.SingleOrDefault(p => p.PizzaToppingId == pizzaToppingDTO.PizzaToppingId);
                pizzaTopping.PizzaToppingPrice = pizzaToppingDTO.PizzaToppingPrice;
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