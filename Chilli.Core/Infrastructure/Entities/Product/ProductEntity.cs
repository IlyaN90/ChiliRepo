using System;
using System.Collections.Generic;
using System.Text;

namespace Chilli.Core.Infrastructure.Entities.Product
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public string Category { get; set; }
    }
}
