using Chilli.Core.Infrastructure.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Order.Models.DBO
{
    public class OrderModel
    {
        public OrderModel(int id, string customer, List<ProductEntity> products, DateTime orderDate, DateTime deadline, double totalPrice, bool success)
        {
            Id = id;
            Customer = customer;
            Products = products;
            OrderDate = orderDate;
            Deadline = deadline;
            TotalPrice = totalPrice;
            Success = success;
        }
        public int Id { get; set; }
        public int MyProperty { get; set; }
        public string Customer { get; set; }
        public List<ProductEntity> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime Deadline { get; set; }
        public double TotalPrice { get; set; }
        public bool Success { get; set; }
    }
}
