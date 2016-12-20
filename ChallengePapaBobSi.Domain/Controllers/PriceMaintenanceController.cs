using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengePapaBobsSi.DTO;

namespace ChallengePapaBobsSi.Domain
{
    public class PriceMaintenanceController
    {
        public static void PizzaSizeDTOUpdateARow(PizzaSizeDTO pizzaSizeDTO)
        {
            Persistence.Repositories.PizzaSizeRepository.PizzaSizeDTOUpdateARow(pizzaSizeDTO);
        }

        public static void PizzaCrustDTOUpdateARow(PizzaCrustDTO pizzaCrustDTO)
        {
            Persistence.Repositories.PizzaCrustRepository.PizzaCrustDTOUpdateARow(pizzaCrustDTO);
        }
        public static void PizzaToppingDTOUpdateARow(PizzaToppingDTO pizzaToppingDTO)
        {
            Persistence.Repositories.PizzaToppingRepository.PizzaToppingDTOUpdateARow(pizzaToppingDTO);
        }
    }
}
