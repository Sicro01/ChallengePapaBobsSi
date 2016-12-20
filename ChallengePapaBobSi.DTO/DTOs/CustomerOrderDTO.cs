using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengePapaBobsSi.DTO
{
    public class CustomerOrderDTO
    {
        public System.Guid CustomerOrderId { get; set; }
        public decimal PizzaSizePrice { get; set; }
        public decimal PizzaCrustPrice { get; set; }
        public decimal PizzaToppingPrice_Sausage { get; set; }
        public decimal PizzaToppingPrice_Pepperoni { get; set; }
        public decimal PizzaToppingPrice_Onions { get; set; }
        public decimal PizzaToppingPrice_GreenPeppers { get; set; }
        public decimal CustomerOrderPrice { get; set; }
        public int CustomerOrderComplete { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerZIP { get; set; }
        public string CustomerPhone { get; set; }
        public System.DateTime CustomerOrderTimeStamp { get; set; }

        public CustomerOrderDTO()
        {
            CustomerOrderId = Guid.NewGuid();
            PizzaToppingPrice_Sausage = 0.0m;
            PizzaToppingPrice_Pepperoni = 0.0m;
            PizzaToppingPrice_Onions = 0.0m;
            PizzaToppingPrice_GreenPeppers = 0.0m;
            CustomerOrderPrice = 0.00m;
            CustomerOrderComplete = 0;
            CustomerName = "";
            CustomerAddress = "";
            CustomerZIP = "";
            CustomerPhone = "";
            CustomerOrderTimeStamp = DateTime.Now;
        }
    }
   
}
