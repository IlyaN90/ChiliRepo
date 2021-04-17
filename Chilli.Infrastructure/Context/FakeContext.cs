using Chilli.Core.Infrastructure.Entities.Order;
using Chilli.Core.Infrastructure.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Infrastructure.Context
{
    public class FakeContext
    {
        public List<ProductEntity> Products{ get; set; }
        public List<OrderEntity> Orders { get; set; }
        public FakeContext()
        {
            Products = new List<ProductEntity>() { };
            Products.Add(new ProductEntity()
            {
                Id = 1,
                Name = "SuperChilli",
                Quantity = 100,
                Cost = 33,
                Category = "Chilly"
            }) ;
            Products.Add(new ProductEntity()
            {
                Id = 2,
                Name = "GreeChilli",
                Quantity = 89,
                Cost = 45,
                Category = "Chilly"
            });
            Products.Add(new ProductEntity()
            {
                Id = 3,
                Name = "RedChilli",
                Quantity = 1000,
                Cost = 50,
                Category = "Chilly"
            });
            Products.Add(new ProductEntity()
            {
                Id = 4,
                Name = "YellowChilli",
                Quantity = 25,
                Cost = 33,
                Category = "Chilly"
            });
            Products.Add(new ProductEntity()
            {
                Id = 5,
                Name = "ChillyChilli",
                Quantity = 1,
                Cost = 999,
                Category = "Chilly"
            });

            Orders = new List<OrderEntity>() { };
            Orders.Add(new OrderEntity()
            {
                Id = 1,
                Customer = "CustomerNumber",
                Products = new List<ProductEntity>(),
                //public List<ProductEntity> Products { get; set; }
                OrderDate = DateTime.Now,
                Deadline = DateTime.Now,
                TotalPrice = 999
            });
        }
    }
}
