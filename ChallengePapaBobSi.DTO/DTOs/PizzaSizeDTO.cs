using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengePapaBobsSi.DTO
{
    public class PizzaSizeDTO
    {
        public System.Guid PizzaSizeId { get; set; }
        public string PizzaSizeName { get; set; }
        public string PizzaSizeDesc { get; set; }
        public decimal PizzaSizePrice { get; set; }
    }
    
}
