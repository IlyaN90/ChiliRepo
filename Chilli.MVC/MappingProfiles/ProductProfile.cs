using AutoMapper;
using Chilli.Core.Infrastructure.Entities.Product;
using Chilli.Core.Product.Models.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilli.MVC.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductModel>().ReverseMap();
        }
    }
}
