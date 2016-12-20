using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using AutoMapper;
using System.Data.Entity.Validation;

namespace ChallengePapaBobsSi.Persistence.Repositories
{
    public class PizzaSizeRepository
    {
        private static readonly IMapper Mapper = AutoMapperPersistenceConfiguration.MapperConfiguration.CreateMapper();
        public static DTOResult GetPizzaSizesDTO()
        {
            DTOResult dtoResult = new DTOResult();
            try
            {
                //1 - Create instance of the database
                PapaBobsPizzasWebAppEntityModel db = new PapaBobsPizzasWebAppEntityModel();
                //2 - Create instance of target table and convert to a List
                var dbPizzaSizes = db.PizzaSizes.ToList();
                //3 - Create list of target DTO objects
                var dtoPizzaSizes = new List<DTO.PizzaSizeDTO>();
                //4 - Add each DAO to the DTO list
                foreach (var dbPizzaSize in dbPizzaSizes)
                {
                    var dtoPizzaSize = Mapper.Map<DTO.PizzaSizeDTO>(dbPizzaSize);
                    dtoPizzaSizes.Add(dtoPizzaSize);
                }
                dtoResult.Success = true;
                dtoResult.DynamicObject = dtoPizzaSizes;
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
        public static void PizzaSizeDTOUpdateARow(DTO.PizzaSizeDTO pizzaSizeDTO)
        {
            //1 - Create instance of the database and add the new Customer Order
            PapaBobsPizzasWebAppEntityModel db = new PapaBobsPizzasWebAppEntityModel();
            try
            {
                var pizzaSize = db.PizzaSizes.SingleOrDefault(p => p.PizzaSizeId == pizzaSizeDTO.PizzaSizeId);
                pizzaSize.PizzaSizeName = pizzaSizeDTO.PizzaSizeName;
                pizzaSize.PizzaSizeDesc = pizzaSizeDTO.PizzaSizeDesc;
                pizzaSize.PizzaSizePrice = pizzaSizeDTO.PizzaSizePrice;
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