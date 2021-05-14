using Chilli.Core.Infrastructure.Entities.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilli.Core.Infrastructure.Entities.Product
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public int Size { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
