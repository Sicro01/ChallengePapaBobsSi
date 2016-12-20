using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengePapaBobsSi.DTO;

namespace ChallengePapaBobsSi.Domain
{
    public class OrderMaintenanceController
    {
        public List<CustomerOrderDTO> customerOrdersDTO = new List<CustomerOrderDTO>();
        public CustomerOrderDTO customerOrderDTO = new CustomerOrderDTO();

        public List<CustomerOrderDTO> GetCustomerOrdersDTO()
        {
            Persistence.Repositories.DTOResult dtoResult = Persistence.Repositories.CustomerOrderRepository.GetCustomerOrdersDTO();
            customerOrdersDTO = (List<CustomerOrderDTO>)dtoResult.DynamicObject;
            customerOrdersDTO.OrderBy(p => p.CustomerOrderTimeStamp);
            return customerOrdersDTO;
        }

        public static void CustomerDTOUpdateARow(Guid customerOrderId, int customerOrderComplete)
        {
            Persistence.Repositories.CustomerOrderRepository.CustomerDTOUpdateARow(customerOrderId, customerOrderComplete);
        }
    }
}
