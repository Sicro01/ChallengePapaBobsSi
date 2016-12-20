using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengePapaBobsSi;
using ChallengePapaBobsSi.DTO;

namespace ChallengePapaBobsSi.Domain
{
    public class OrderController
    {
        public static List<PizzaSizeDTO> pizzaSizesDTO = new List<PizzaSizeDTO>();
        public static List<PizzaCrustDTO> pizzaCrustsDTO = new List<PizzaCrustDTO>();
        public static List<PizzaToppingDTO> pizzaToppingsDTO = new List<PizzaToppingDTO>();
        public static CustomerOrderDTO customerOrderDTO = new CustomerOrderDTO();
        public static List<CustomerOrderDTO> customerOrdersDTO = new List<CustomerOrderDTO>();
        
        public List<PizzaSizeDTO> GetPizzaSizesDTO()
        {
            Persistence.Repositories.DTOResult dtoResult = Persistence.Repositories.PizzaSizeRepository.GetPizzaSizesDTO();
            pizzaSizesDTO = (List<PizzaSizeDTO>)dtoResult.DynamicObject;
            return pizzaSizesDTO;
        }
        public List<PizzaCrustDTO> GetPizzaCrustsDTO()
        {
            Persistence.Repositories.DTOResult dtoResult = Persistence.Repositories.PizzaCrustRepository.GetPizzaCrustsDTO();
            pizzaCrustsDTO = (List<PizzaCrustDTO>)dtoResult.DynamicObject;
            return pizzaCrustsDTO;
        }
        
        public List<PizzaToppingDTO> GetPizzaToppingsDTO()
        {
            Persistence.Repositories.DTOResult dtoResult = Persistence.Repositories.PizzaToppingRepository.GetPizzaToppingsDTO();
            pizzaToppingsDTO = (List<DTO.PizzaToppingDTO>)dtoResult.DynamicObject;
            return pizzaToppingsDTO;
        }

        public static decimal PriceOrder()
        {
            customerOrderDTO.CustomerOrderPrice =
            customerOrderDTO.PizzaSizePrice +
            customerOrderDTO.PizzaCrustPrice +
            customerOrderDTO.PizzaToppingPrice_Sausage +
            customerOrderDTO.PizzaToppingPrice_Pepperoni +
            customerOrderDTO.PizzaToppingPrice_Onions +
            customerOrderDTO.PizzaToppingPrice_GreenPeppers;

            return customerOrderDTO.CustomerOrderPrice;
        }
        public static void CustomerDTOAddARow(CustomerOrderDTO customerOrderDTO)
        {
            Persistence.Repositories.CustomerOrderRepository.CustomerDTOAddARow(customerOrderDTO);
        }
    }
}