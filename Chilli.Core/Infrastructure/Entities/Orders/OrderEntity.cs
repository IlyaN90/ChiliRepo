using Chilli.Core.Infrastructure.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Infrastructure.Entities.Order
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public List<ProductEntity> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime Deadline { get; set; }
        public double TotalPrice { get; set; }

        public bool Success = true;
    }
}
