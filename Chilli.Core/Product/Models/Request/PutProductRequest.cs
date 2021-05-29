using Chilli.Core.Product.Models.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Product.Models
{
    public class PutProductRequest 
    { 
        public PutProductRequest(int id, string name, string description, double cost, int size, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Cost = cost;
            Size = size;
            CategoryId = categoryId;
        }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Cost { get; set; }
    public int Size { get; set; }
    public int CategoryId { get; set; }
    }
}
