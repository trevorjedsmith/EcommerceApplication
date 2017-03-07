using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStoreAngular1.models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int count { get; set; }
        public int productid { get; set; }
        public decimal price { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
