//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChallengePapaBobsSi.Persistence
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerOrder
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
    }
}
