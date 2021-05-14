using Chilli.Core.Infrastructure.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Product.Models.DBO
{
    public class ProductModel
    {
        public ProductModel()
        {

        }
        public ProductModel(int id, string name, string description, double cost, int size)
        {
            Id = id;
            Name = name;
            Description = description;
            Cost = cost;
            Size = size;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public int Size { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
