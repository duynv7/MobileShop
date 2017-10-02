using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobildeShop.Models.ViewModels
{
    public class OrderCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderCustomer(Order order)
        {
            this.order = order;
        }

        public Order order;
        public int remainingMonth;
        public float remainingAmount;
    }
}