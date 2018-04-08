using System.Collections.Generic;

namespace Binding.StaticResource.AddNew.Model
{
    public class Order
    {
        public int orderID { get; set; }
        public Customer customer { get; set; }


        public List<OrderItem> items { get; set; }
    }
}
